using Crosscutting.ViewModels;
using Football.BlobStorage.Interfaces;
using Football.Crosscutting.ViewModels.TopSquad;
using Football.DataAccessEFCore3.Interface;
using Football.Services.Interface;
using Football.Services.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Services.Concrete
{
    public class TopSquadService : ITopSquadService
    {
        private ITopSquadApiClient _topSquadApiClient;
        private IPlayerRepository _playerRepository;
        private IBlobStorageService _blobStorageService;

        public TopSquadService(ITopSquadApiClient topSquadApiClient, IPlayerRepository playerRepository, IBlobStorageService blobStorageService)
        {
            _topSquadApiClient = topSquadApiClient;
            _playerRepository = playerRepository;
            _blobStorageService = blobStorageService;
        }

        public async Task<IEnumerable<Player>> GetTopSquad()
        {
            var allTopSquads = await _topSquadApiClient.GetAllTopSquads();

            var sortedPlayers = allTopSquads
                .SelectMany(x => x.squad).GroupBy(x => x.id)
                .Select(x => new { 
                    Id = x.Key,
                    Count = x.Count(),
                    PositionCode = x.ToList()[0].positionCode})
                .OrderBy(x => x.PositionCode).ThenByDescending(x=>x.Count);

            var goalkeeper = sortedPlayers.Where(x => x.PositionCode == 1).Take(1);
            var defenders = sortedPlayers.Where(x => x.PositionCode == 2).Take(4);
            var midfielders = sortedPlayers.Where(x => x.PositionCode == 3).Take(4);
            var forwards = sortedPlayers.Where(x => x.PositionCode == 4).Take(2);

            var toReturn = goalkeeper.Concat(defenders).Concat(midfielders).Concat(forwards).Select(x=>Int32.Parse(x.Id));

            var topSquad = await _playerRepository.GetPlayersFromList(toReturn);

            foreach (var player in topSquad)
            {
                _blobStorageService.PopulateUrlForBlob(player.Picture);
            }

            return topSquad.OrderBy(x=>x.PositionCode);
        }
    }
}
