using Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.Competition
{
    public class Booking
    {
        public Player Player { get; set; }

        public string Type { get; set; }

        public int Minute { get; set; }
    }
}
