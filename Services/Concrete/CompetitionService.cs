using Football.BlobStorage.Interfaces;
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
    }
}
