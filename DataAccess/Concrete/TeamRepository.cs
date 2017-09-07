using Crosscutting.ViewModels;
using DataAccess.Interface;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using DataAccess.Concrete;
using Football.DataAccess.Interface;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting;

namespace Football.DataAccess.Concrete
{
    public class TeamRepository : EFRepositoryBase, ITeamRepository
    {
        public TeamRepository(c__database_futbol_mdfContext context) : base(context)
        {
        }

        public Team GetTeamByIdAndYear(int id, int year)
        {
            var teamFromBD = _context.Equipo
                .Include(x => x.Jugador)
                .ThenInclude(x=>x.CodIntegranteNavigation.HcoIntegrante)
                .FirstOrDefault(x => x.CodEquipo == id);

            var team = new Team()
            {
                Id = id,
                Name = teamFromBD.Nombre,
                PlayerList = teamFromBD.Jugador.Where(x=>x.CodIntegranteNavigation.HcoIntegrante.Any(hco=>hco.FechaInicio.Year == year))
                .Select(x=>new Player()
                {
                    Name = x.CodIntegranteNavigation.Nombre,
                    Surname = x.CodIntegranteNavigation.Apellidos,
                    TeamName = teamFromBD.Nombre
                }).ToList()
            };

            return team;
        }

        public List<Team> GetAllTeams()
        {
            return _context.Equipo.Select(equipo => new Team()
            {
                Id = equipo.CodEquipo,
                Name = equipo.Nombre,
                PictureUrl = equipo.FotoEscudo
            }).ToList();
        }

        public void AddTeamPicture(int teamId, BlobData mediaItem)
        {
            var team = _context.Equipo.FirstOrDefault(x => x.CodEquipo == teamId);

            team.TeamPicture = new GlobalMedia()
            {
                BlobStorageContainer = "mycontainer",
                BlobStorageReference = mediaItem.FileName,
                FileName = mediaItem.FileName
            };

            _context.SaveChanges();
        }
    }
}
