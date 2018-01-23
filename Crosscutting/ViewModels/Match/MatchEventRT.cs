using Football.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Crosscutting.ViewModels.Match
{
    public class MatchEventRT
    {
        public MatchEventTypeEnum MatchEventType { get; set; }

        public int Minute { get; set; }

        public string Description { get; set; }

        public int Player1 { get; set; }

        public int? Player2 { get; set; }
    }
}
