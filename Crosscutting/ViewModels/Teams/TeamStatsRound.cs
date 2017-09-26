using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.Teams
{
    public class TeamStatsRound
    {

        public int Position { get; set; }

        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public BlobData TeamLogo { get; set; }

        public int? GoalsFor { get; set; }

        public int? GoalsAgainst { get; set; }

        public int? MatchesWon { get; set; }

        public int? MatchesDraw { get; set; }

        public int? MatchesLost { get; set; }

        public int? Points { get; set; }
    }
}
