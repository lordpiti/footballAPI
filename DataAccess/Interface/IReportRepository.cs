using Football.Crosscutting.ViewModels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccess.Interface
{
    public interface IReportRepository
    {
        Task<List<BaseItem>> GetMatchReportData(int matchId);
    }
}
