using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels
{
    public class Calendar
    {
        public Team Localteam { get; set; }

        public Team AwayTeam { get; set; }

        public DateTime? Date { get; set; }

        public int GoalsLocal { get; set; }

        public int GoalsAway { get; set; }
    }
}
