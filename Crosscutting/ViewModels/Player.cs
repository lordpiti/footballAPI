using System;
using System.Collections.Generic;
using System.Text;

namespace Crosscutting.ViewModels
{
    public class Player
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string TeamName { get; set; }

        public int PlayerId { get; set; }

        public int TeamId { get; set; }

        public int? Dorsal { get; set; }
    }
}
