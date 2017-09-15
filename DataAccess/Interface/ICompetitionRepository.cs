using Football.Crosscutting.ViewModels.Competition;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccess.Interface
{
    public interface ICompetitionRepository
    {
        Task<List<Competition>> GetCompetitions(int? teamId = null, string season = null);
    }
}
