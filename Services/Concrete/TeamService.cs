using Football.BlobStorage.Interfaces;
using Football.Crosscutting;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Teams;
using Football.DataAccess.Interface;
using Football.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IBlobStorageService _blobStorageService;

        public TeamService(ITeamRepository teamRepository, IBlobStorageService blobStorageService)
        {
            _teamRepository = teamRepository;
            _blobStorageService = blobStorageService;
        }

        public async Task<Team> GetTeamByIdAndYear(int id, int year)
        {
            var team = await _teamRepository.GetTeamByIdAndYear(id, year);

            if (team!=null)
            {
                _blobStorageService.PopulateUrlForBlob(team.PictureLogo);
            }

            return team;
        }

        public async Task<List<Team>> GetAllTeams(int? competitionId = null)
        {
            return await _teamRepository.GetAllTeams(competitionId);
        }

        public async Task AddTeamPicture(int teamId, BlobData mediaItem)
        {
            await _teamRepository.AddTeamPicture(teamId, mediaItem);
        }

        public async Task<int> UpdateTeam(Team team)
        {
            return await _teamRepository.UpdateTeam(team);
        }

        public async Task<ClasificationChartData> GetTeamSeasonClasificationChartData(int teamId,
            string competitionName, string season)
        {
            return await _teamRepository.GetTeamSeasonClasificationChartData(teamId, competitionName, season);
        }

        public async Task<ClasificationChartData> GetTeamSeasonClasificationChartData(int teamId, int competitionId)
        {
            return await _teamRepository.GetTeamSeasonClasificationChartData(teamId, competitionId);
        }
    }
}
