using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.Competition
{
    public class Competition
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Season { get; set; }

        public string Type { get; set; }

        public BlobData Logo { get; set; }
    }
}
