﻿using Football.Crosscutting.ViewModels.Reports;
using Football.DataAccess.Interface;
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
        private readonly IReportNoSQLRepository _reportNoSQLRepository;

        public ReportService(IReportRepository reportRepository, IReportNoSQLRepository reportNoSQLRepository)
        {
            _reportRepository = reportRepository;
            _reportNoSQLRepository = reportNoSQLRepository;
        }

        public async Task<List<BaseItem>> GenerateReport(int matchId)
        {
            var reportItems = await _reportRepository.GetMatchReportData(matchId);

            var report = new ReportData()
            {
                MatchId = matchId,
                ReportItems = reportItems
            };

            _reportNoSQLRepository.CreateReport(report);

            return reportItems;
        }

        public ReportData GetReportSnapshot(int matchId)
        {
            return _reportNoSQLRepository.GetReportSnapshot(matchId);
        }
    }
}
