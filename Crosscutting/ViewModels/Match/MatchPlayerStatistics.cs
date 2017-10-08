using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.Match
{
    public class MatchPlayerStatistics
    {
        public string Starting { get; set; }

        public int Minutes { get; set; }

        public int Assistances { get; set; }

        public int RecoveredBalls {get;set;}

        public int MissedBalls { get; set; }

        public int ShotsOnTarget { get; set; }

        public int Shots { get; set; }

        public int FaulsReceived { get; set; }

        public int Fauls { get; set; }
    }
}
