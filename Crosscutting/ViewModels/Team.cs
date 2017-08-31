using Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels
{
    public class Team
    {
        public int Id { get; set; }

        public List<Player> PlayerList { get; set; }

        public string Name { get; set; }

        public string PictureUrl { get; set; }
    }
}
