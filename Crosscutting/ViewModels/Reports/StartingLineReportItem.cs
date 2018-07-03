using Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Crosscutting.ViewModels.Reports
{
    public class StartingLineReportItem : BaseItem
    {
        public StartingLineReportItem()
        {
            this.ItemType = Enums.MatchEventTypeEnum.StartingLine;
        }

        public Team Team { get; set; }

        public List<Player> PlayerList { get; set; }
    }
}
