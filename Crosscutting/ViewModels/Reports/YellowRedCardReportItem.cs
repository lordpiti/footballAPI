using Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Crosscutting.ViewModels.Reports
{
    public class YellowRedCardReportItem : BaseItem
    {
        public Player Player { get; set; }

        public string Reason { get; set; }
    }
}
