using System;
using System.Collections.Generic;
using System.Text;

namespace Crosscutting.ViewModels
{
    public class MatchPlayedInfo
    {
        public DateTime? Date { get; set; }

        public int LocalGoals { get; set; }

        public int VisitorGoals { get; set; }

        public int RecoveredBalls { get; set; }
    }
}
