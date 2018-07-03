using Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Crosscutting.ViewModels.Reports
{
    public class SubstitutionReportItem : BaseItem
    {
        public SubstitutionReportItem()
        {
            this.ItemType = Enums.MatchEventTypeEnum.Substitution;
        }

        public Player PlayerOut { get; set; }

        public Player PlayerIn { get; set; }

        public int Reason { get; set; }
    }
}
