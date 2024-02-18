using Football.Crosscutting.ViewModels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccessNoSQL.Interface
{
    public interface IReportNoSQLRepository : IMongoRepository<ReportData>
    {
        Task CreateReport(ReportData reportData);

        //Task<ReportData> GetReportSnapshot(int matchId);
    }
}
