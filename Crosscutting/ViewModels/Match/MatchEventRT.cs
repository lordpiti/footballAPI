using Crosscutting.ViewModels;
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
        public int MatchId { get; set; }

        public MatchEventTypeEnum MatchEventType { get; set; }

        public int Minute { get; set; }

        public string Description { get; set; }

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }
    }
}
