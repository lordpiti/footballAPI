using Football.MigrationTool.DataMigrations;
using System;
using System.Threading.Tasks;

namespace Football.MigrationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new PositionsMigration(null);

            try
            {
                var t = Task.Run( async () => {
                    await a.Execute(); });

                t.Wait();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
