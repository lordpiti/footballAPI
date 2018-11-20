using System;
using System.Threading.Tasks;

namespace Football.MigrationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new SearchAndPopulateMigration(null, null, null);

            Task.Run(() => a.Execute());
        }
    }
}
