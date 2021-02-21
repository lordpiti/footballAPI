using Crosscutting.ViewModels;
using Football.Crosscutting;
using Football.Crosscutting.ViewModels;
using Football.DataAccessEFCore3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Mappers
{
    public static class TeamMapper
    {
        public static Team Map(Equipo teamFromBD, int year)
        {
            var team = new Team()
            {
                Id = teamFromBD.CodEquipo,
                Name = teamFromBD.Nombre,
                City = teamFromBD.Localidad,
                Stadium = new Stadium()
                {
                    Address = teamFromBD.CodEstadioNavigation.Direccion,
                    Id = teamFromBD.CodEstadioNavigation.CodEstadio,
                    Name = teamFromBD.CodEstadioNavigation.Nombre,
                    Capacity = teamFromBD.CodEstadioNavigation.Capacidad
                },
                PictureLogo = teamFromBD.TeamPictureGlobalMedia != null ? new BlobData()
                {
                    ContainerReference = teamFromBD.TeamPictureGlobalMedia.BlobStorageContainer,
                    FileName = teamFromBD.TeamPictureGlobalMedia.BlobStorageReference
                } : new BlobData() { },
                PlayerList = teamFromBD.Jugador.Where(x => x.CodIntegranteNavigation.HcoIntegrante.Any(hco => hco.FechaInicio.Year == year))
                    .Select(x => new Player()
                    {
                        Name = x.CodIntegranteNavigation.Nombre,
                        Surname = x.CodIntegranteNavigation.Apellidos,
                        TeamName = teamFromBD.Nombre,
                        BirthDate = x.CodIntegranteNavigation.FechaNac,
                        Position = x.Posicion,
                        BirthPlace = x.CodIntegranteNavigation.BirthPlace,
                        Height = x.Altura,
                        PlayerId = x.CodJugador,
                        Dorsal = x.CodIntegranteNavigation.HcoIntegrante.FirstOrDefault(hco => hco.FechaInicio.Year == year).Dorsal,
                        Picture = x.CodIntegranteNavigation.PictureGlobalMedia != null ? new BlobData()
                        {
                            ContainerReference = x.CodIntegranteNavigation.PictureGlobalMedia.BlobStorageContainer,
                            FileName = x.CodIntegranteNavigation.PictureGlobalMedia.BlobStorageReference
                        } : new BlobData() { },
                    }).ToList()
            };

            return team;
        }

        public static Equipo Map(Team team)
        {
            var teamFromBd = new Equipo()
            {
                CodEquipo = team.Id,
                Nombre = team.Name,
                Localidad = team.City,
                TeamPictureGlobalMedia = team.PictureLogo != null ? new GlobalMedia()
                {
                    BlobStorageReference = team.PictureLogo.FileName,
                    FileName = team.PictureLogo.FileName,
                    BlobStorageContainer = "mycontainer"
                } : new GlobalMedia()
            };

            return teamFromBd;
        }

        public static IEnumerable<Team> Map(IEnumerable<Equipo> teams)
        {
            return teams.Select(x =>
                new Team()
                {
                    Id = x.CodEquipo,
                    Name = x.Nombre,
                    PictureLogo = new BlobData()
                    {
                        FileName = x.TeamPictureGlobalMedia.BlobStorageReference,
                        ContainerReference = x.TeamPictureGlobalMedia.BlobStorageContainer
                    }
                }).ToList();
        }
    }
}
