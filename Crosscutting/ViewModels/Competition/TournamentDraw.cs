using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Crosscutting.ViewModels.Competition
{
    public class TournamentDraw
    {
        public List<MatchGeneralInfo> EightLeft { get; set; }

        public List<MatchGeneralInfo> EightRight { get; set; }

        public List<MatchGeneralInfo> QuarterFinalsLeft { get; set; }

        public List<MatchGeneralInfo> QuarterFinalsRight { get; set; }

        public MatchGeneralInfo SemifinalsLeft { get; set; }

        public MatchGeneralInfo SemifinalsRight { get; set; }

        public MatchGeneralInfo Final { get; set; }
    }
}
