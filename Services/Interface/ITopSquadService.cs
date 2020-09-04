using Football.Crosscutting.ViewModels.TopSquad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Interface
{
    public interface ITopSquadService
    {
        Task<IEnumerable<TopSquad>> Test();
    }
}
