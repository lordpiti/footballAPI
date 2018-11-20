using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.MigrationTool.HelperClasses
{

    public class Player
    {
        public string name { get; set; }
        public string bio { get; set; }
        public string photo_done { get; set; }
        public string special_player  { get; set; }
        public string position { get; set; }
        public string number { get; set; }
        public string caps { get; set; }
        public string goals_for_country { get; set; }
        public string club { get; set; }
        public string league { get; set; }
        public string date_of_birth { get; set; }
        public string rating_match1 { get; set; }
        public string rating_match2 { get; set; }
        public string rating_match3 { get; set; }
    }

    public class Sheets
    {
        public List<Player> Players { get; set; }
    }

    public class RootObject
    {
        public Sheets sheets { get; set; }
    }
}
