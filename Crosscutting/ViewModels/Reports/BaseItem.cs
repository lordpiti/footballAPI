using Football.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Crosscutting.ViewModels.Reports
{
    public class BaseItem
    {
        public int MatchId { get; set; }

        public int? CompetitionId { get; set; }

        public BlobData Image { get; set; }

        public MatchEventTypeEnum ItemType { get; set; }

        public int Minute { get; set; }
    }
}
