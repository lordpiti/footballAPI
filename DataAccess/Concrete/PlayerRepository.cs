using Crosscutting.ViewModels;
using DataAccess.Interface;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class PlayerRepository: EFRepositoryBase, IPlayerRepository
    {
        public PlayerRepository(c__database_futbol_mdfContext context) : base(context)
        {
        }

        public List<Player> GetAllPlayers()
        {
            return _context.Jugador.Include(x => x.CodIntegranteNavigation).Include(x=>x.CodEquipoNavigation).Select(x => new Player()
            {
                Name = x.CodIntegranteNavigation.Nombre,
                Surname = x.CodIntegranteNavigation.Apellidos,
                TeamName = x.CodEquipoNavigation.Nombre
            }).ToList();
        }

        public List<MatchPlayedInfo> GetMatchesPlayed(int id)
        {
            //https://docs.microsoft.com/en-us/ef/core/querying/related-data#related-data-and-serialization
            var toReturn = _context.Jugador.Include(x=>x.PartidoJugado)
                .ThenInclude(partidoJugado => partidoJugado.CodPartidoNavigation)
                .FirstOrDefault(x => x.CodJugador == id)
                .PartidoJugado.Select(x => new MatchPlayedInfo(){
                    Date = x.CodPartidoNavigation.Fecha,
                    LocalGoals = x.CodPartidoNavigation.GolesLocal,
                    VisitorGoals = x.CodPartidoNavigation.GolesVisitante,
                    RecoveredBalls = x.BalonesRecuperados 
                }).ToList();

            return toReturn;
        }
    }
}
