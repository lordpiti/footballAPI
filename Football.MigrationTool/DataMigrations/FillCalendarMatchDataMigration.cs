using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Football.DataAccessEFCore3.Models;

namespace Football.MigrationTool.DataMigrations
{
    public class FillCalendarMatchDataMigration
    {
        private static DbContextOptions _contextOptions;

        public void Execute()
        {
            _contextOptions = new DbContextOptionsBuilder<FootballContext>()
            .UseSqlServer(@"Server=tcp:qdijnzq4jx.database.windows.net,1433;Initial Catalog=Football;Persist Security Info=False;User ID=lordpiti@qdijnzq4jx;Password=Kidswast1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            .Options;

            var context = new FootballContext((DbContextOptions<FootballContext>)_contextOptions);

            var b = context.Calendario;

            foreach(var item in b)
            {
                var matchFound = context.Partido.FirstOrDefault(x => x.CodCompeticion == item.CodCompeticion
                    && x.Jornada == item.Jornada && x.CodLocal == item.CodLocal && x.CodVisitante == item.CodVisitante);

                if (matchFound != null)
                {
                    item.MatchCodPartidoNavigation = matchFound;
                }
            }
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
