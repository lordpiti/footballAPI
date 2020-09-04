using Football.Crosscutting.ViewModels.TopSquad;
using Football.Services.Interface;
using Football.Services.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Concrete
{
    public class TopSquadService : ITopSquadService
    {
        private ITopSquadApiClient _topSquadApiClient;

        public TopSquadService(ITopSquadApiClient topSquadApiClient)
        {
            _topSquadApiClient = topSquadApiClient;
        }

        public async Task<IEnumerable<TopSquad>> Test()
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

            var toReturn = goalkeeper.Concat(defenders).Concat(midfielders).Concat(forwards);

            return allTopSquads;
        }
    }
}
