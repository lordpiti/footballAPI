using Football.Crosscutting.ViewModels.Competition;
using Football.Crosscutting.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels
{
    public class CompetitionRoundData
    {
        public List<TeamStatsRound> TeamStatsRoundList { get; set; }

        public List<MatchGeneralInfo> MatchList { get; set; }

        public List<Scorer> Scorers { get; set; }
    }
}
