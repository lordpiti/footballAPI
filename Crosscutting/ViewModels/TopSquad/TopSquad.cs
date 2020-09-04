using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.TopSquad
{
    public class TopSquad
    {
        public string userId { get; set; }

        public IEnumerable<PlayerSelected> squad { get; set; }
    }

    public class PlayerSelected
    {
        public string id { get; set; }

        public int positionCode { get; set; }
    }
}
