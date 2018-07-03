using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Crosscutting.ViewModels.Reports
{
    public class ReportData
    {
        public List<BaseItem> ReportItems { get; set; }

        public int MatchId { get; set; }
    }
}
