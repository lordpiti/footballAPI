using Football.BlobStorage.Interfaces;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Teams;
using Football.DataAccessEFCore3.Concrete;
using Football.DataAccessEFCore3.Models;
using Football.Services.Interface;
using Football.Services.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Services.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly IFootballUnitOfWork _footballUnitOfWork;

        public TeamService(IBlobStorageService blobStorageService, IFootballUnitOfWork footballUnitOfWork)
        {
            _blobStorageService = blobStorageService;
            _footballUnitOfWork = footballUnitOfWork;
        }

        public async Task<Team> GetTeamByIdAndYear(int id, int year)
        {
            var teamfromBD = await _footballUnitOfWork.TeamRepository.GetTeamByIdAndYear(id);

            var team = TeamMapper.Map(teamfromBD, year);

            if (team!=null)
            {
                _blobStorageService.PopulateUrlForBlob(team.PictureLogo);

                foreach (var player in team.PlayerList)
                {
                    _blobStorageService.PopulateUrlForBlob(player.Picture);
                }
            }

            return team;
        }

        public async Task<IEnumerable<Team>> GetAllTeams(int? competitionId = null)
        {
            var teamsFromBD = await _footballUnitOfWork.TeamRepository.GetAllTeams(competitionId);

            var teams = TeamMapper.Map(teamsFromBD);

            foreach (var team in teams)
            {
                _blobStorageService.PopulateUrlForBlob(team.PictureLogo);
            }

            return teams;
        }

        public async Task<int> UpdateTeam(Team team)
        {
            var teamOnDb = Mappers.TeamMapper.Map(team);

            var imageExists = await _footballUnitOfWork.GlobalMediaRepository.FindByCondition(x => x.BlobStorageReference == team.PictureLogo.BlobStorageReference);

            if (imageExists == null)
            {
                imageExists = new GlobalMedia()
                {
                    BlobStorageReference = team.PictureLogo.BlobStorageReference,
                    FileName = team.PictureLogo.FileName,
                    BlobStorageContainer = "mycontainer"
                };
            }

            teamOnDb.TeamPictureGlobalMedia = imageExists;

            await _footballUnitOfWork.TeamRepository.SaveTeam(teamOnDb);

            return await _footballUnitOfWork.CommitAsync();
        }

        public async Task<ClasificationChartData> GetTeamSeasonClasificationChartData(int teamId,
            string competitionName, string season)
        {
            var clasificationDataFromDb = await _footballUnitOfWork.TeamRepository.GetTeamSeasonClasificationChartData(teamId, competitionName, season);

            var clasificationSeasonData = clasificationDataFromDb.Select(x => new ClasificationRoundData()
            {
                Position = x.Posicion,
                GoalsAgainst = x.GolesContra,
                GoalsFor = x.GolesFavor,
                Round = x.Jornada
            }).ToList();

            var team = await _footballUnitOfWork.TeamRepository.GetTeamByIdAndYear(teamId);

            return new ClasificationChartData()
            {
                Season = season,
                TeamName = team.Nombre,
                ClasificationSeasonData = clasificationSeasonData
            };

        }

        public async Task<ClasificationChartData> GetTeamSeasonClasificationChartData(int teamId, int competitionId)
        {
            return await _footballUnitOfWork.TeamRepository.GetTeamSeasonClasificationChartData(teamId, competitionId);
        }
    }
}
