using Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Competition;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.Match
{
    public class MatchPlayerDataTotal : Player
    {
        public IEnumerable<Booking> Bookings { get; set; }
        public IEnumerable<Goal> Goals { get; set; }
    }
}
