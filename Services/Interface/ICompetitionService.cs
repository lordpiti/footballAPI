﻿using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Competition;
using Football.Crosscutting.ViewModels.Match;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Interface
{
    public interface ICompetitionService
    {
        Task<List<Competition>> GetCompetitions(int? teamId = null, string season = null);

        Task<CompetitionRoundData> GetCompetitionRoundData(int competitionId, string round);

        Task<MatchOverview> GetMatchOverview(int matchId);
    }
}
