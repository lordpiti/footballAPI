using Football.Crosscutting.ViewModels.TopSquad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Proxy
{
    public interface ITopSquadApiClient
    {
        Task<IEnumerable<TopSquad>> GetAllTopSquads();
    }
}
