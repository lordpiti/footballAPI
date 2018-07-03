using Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Crosscutting.ViewModels.Reports
{
    public class GoalReportItem : BaseItem
    {
        public GoalReportItem()
        {
            this.ItemType = Enums.MatchEventTypeEnum.Goal;
        }

        public Player Scorer { get; set; }

        public string VideoUrl { get; set; }
    }
}
