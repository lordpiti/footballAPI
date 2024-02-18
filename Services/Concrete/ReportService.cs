using Football.Crosscutting.ViewModels.Reports;
using Football.DataAccessEFCore3.Interface;
using Football.DataAccessNoSQL.Interface;
using Football.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Concrete
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly ICompetitionRepository _competitionRepository;
        private readonly IReportNoSQLRepository _reportNoSQLRepository;

        public ReportService(IReportRepository reportRepository, IReportNoSQLRepository reportNoSQLRepository,
            ICompetitionRepository competitionRepository)
        {
            _reportRepository = reportRepository;
            _reportNoSQLRepository = reportNoSQLRepository;
            _competitionRepository = competitionRepository;
        }

        public async Task<ReportData> GenerateReport(int matchId)
        {
            var reportItems = await _reportRepository.GetMatchReportData(matchId);
            var matchInfo = await _competitionRepository.GetMatchOverview(matchId);

            var report = new ReportData()
            {
                ReportItems = reportItems,
                MatchGeneralInfo = matchInfo,
                MatchId = matchId
            };

            await _reportNoSQLRepository.CreateReport(report);

            return report;
        }

        public async Task<ReportData> GetReportSnapshot(int matchId)
        {
            //return await _reportNoSQLRepository.GetReportSnapshot(matchId);
            return await _reportNoSQLRepository.FindByExpression(x => x.MatchId == matchId);
        }
    }
}
