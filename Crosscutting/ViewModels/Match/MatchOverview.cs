using Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Competition;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.Match
{
    public class MatchOverview
    {
        public List<Player> Players { get; set; }

        public MatchGeneralInfo MatchGeneralInfo { get; set; }
    }
}
