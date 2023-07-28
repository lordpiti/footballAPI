using Football.Crosscutting.ViewModels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Interface
{
    public interface IReportService
    {
        Task<ReportData> GenerateReport(int matchId);

        Task<ReportData> GetReportSnapshot(int matchId);
    }
}
