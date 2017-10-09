using Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.Competition
{
    public class Substitution
    {
        public Player PlayerOut { get; set; }

        public Player PlayerIn { get; set; }

        public int Minute { get; set; }
    }
}
