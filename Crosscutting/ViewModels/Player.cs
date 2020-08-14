using Football.Crosscutting;
using Football.Crosscutting.Enums;
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

        public bool Start { get; set; }

        public DateTime? BirthDate { get; set; }

        public BlobData Picture { get; set; }

        public float? Height { get; set; }

        public string Position { get; set; }

        public string BirthPlace { get; set; }

        public PositionEnum? PositionCode {get;set;}
    }
}
