using Football.BlobStorage.Interfaces;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Competition;
using Football.Crosscutting.ViewModels.Match;
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
            var competitionData = await _competitionRepository.GetCompetitionRoundData(competitionId, round);

            foreach (var item in competitionData.MatchList)
            {
                _blobStorageService.PopulateUrlForBlob(item.LocalTeam.PictureLogo);
                _blobStorageService.PopulateUrlForBlob(item.VisitorTeam.PictureLogo);
            }

            foreach (var item in competitionData.TeamStatsRoundList)
            {
                _blobStorageService.PopulateUrlForBlob(item.TeamLogo);
            }

            var scorers = await _competitionRepository.GetTopScorers(competitionId, round);
            competitionData.Scorers = scorers;

            return competitionData;
        }

        public async Task<MatchOverview> GetMatchOverview(int matchId)
        {
            return await _competitionRepository.GetMatchOverview(matchId);
        }

        public async Task<Competition> GetCompetitionById(int competitionId)
        {
            var competition = await _competitionRepository.GetCompetitionById(competitionId);

            _blobStorageService.PopulateUrlForBlob(competition.Logo);

            return competition;
        }

        public async Task<List<Scorer>> GetTopScorers(int competitionId, string round)
        {
            return await _competitionRepository.GetTopScorers(competitionId, round);
        }
    }
}
