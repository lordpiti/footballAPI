using Football.Crosscutting.ViewModels.Competition;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crosscutting.ViewModels
{
    public class MatchPlayedInfo
    {
        public DateTime? Date { get; set; }

        public Competition Competition { get; set; }

        public string LocalTeamName { get; set; }

        public string VisitorTeamName { get; set; }

        public int LocalGoals { get; set; }

        public int VisitorGoals { get; set; }

        public int RecoveredBalls { get; set; }

        public int Id { get; set; }
    }
}
