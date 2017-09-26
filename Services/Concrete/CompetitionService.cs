using Football.BlobStorage.Interfaces;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Competition;
using Football.DataAccess.Interface;
using Football.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Concrete
{
    public class CompetitionService : ICompetitionService
    {
        private readonly ICompetitionRepository _competitionRepository;
        private readonly IBlobStorageService _blobStorageService;

        public CompetitionService(ICompetitionRepository competitionRepository, IBlobStorageService blobStorageService)
        {
            _competitionRepository = competitionRepository;
            _blobStorageService = blobStorageService;
        }

        public async Task<List<Competition>> GetCompetitions(int? teamId = null, string season = null)
        {
            return await _competitionRepository.GetCompetitions(teamId, season);
        }

        public async Task<CompetitionRoundData> GetCompetitionRoundData(int competitionId, string round)
        {
            var bu = await _competitionRepository.GetCompetitionRoundData(competitionId, round);

            foreach (var item in bu.MatchList)
            {
                _blobStorageService.PopulateUrlForBlob(item.LocalTeam.PictureLogo);
                _blobStorageService.PopulateUrlForBlob(item.VisitorTeam.PictureLogo);
            }

            foreach (var item in bu.TeamStatsRoundList)
            {
                _blobStorageService.PopulateUrlForBlob(item.TeamLogo);
            }

            return bu;
        }
    }
}
