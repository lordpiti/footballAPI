using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.Teams
{
    public class ClasificationChartData
    {
        public List<ClasificationRoundData> ClasificationSeasonData { get; set; }

        public string TeamName { get; set; }

        public string Season { get; set; }
    }

    public class ClasificationRoundData
    {
        public int Position { get; set; }

        public int? GoalsFor { get; set; }

        public int? GoalsAgainst { get; set; }
    }
}
