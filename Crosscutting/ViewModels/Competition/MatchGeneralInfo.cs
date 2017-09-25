using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.Competition
{
    public class MatchGeneralInfo
    {
        public DateTime? Date { get; set; }

        public Stadium Stadium { get; set; }

        public Team LocalTeam { get; set; }

        public Team VisitorTeam { get; set; }

        public int? GoalsLocal { get; set; }

        public int? GoalsVisitor { get; set; }

        public int? MatchId { get; set; }
    }
}
