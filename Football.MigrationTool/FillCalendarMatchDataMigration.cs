using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Football.MigrationTool
{
    public class FillCalendarMatchDataMigration
    {
        private static DbContextOptions _contextOptions;

        public void Execute()
        {
            _contextOptions = new DbContextOptionsBuilder<c__database_futbol_mdfContext>()
            .UseSqlServer(@"Server=tcp:qdijnzq4jx.database.windows.net,1433;Initial Catalog=Football;Persist Security Info=False;User ID=lordpiti@qdijnzq4jx;Password=Kidswast1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            .Options;

            var context = new c__database_futbol_mdfContext((DbContextOptions<c__database_futbol_mdfContext>)_contextOptions);

            var b = context.Calendario;

            foreach(var item in b)
            {
                var matchFound = context.Partido.FirstOrDefault(x => x.CodCompeticion == item.CodCompeticion
                    && x.Jornada == item.Jornada && x.CodLocal == item.CodLocal && x.CodVisitante == item.CodVisitante);

                if (matchFound != null)
                {
                    item.Match = matchFound;
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
