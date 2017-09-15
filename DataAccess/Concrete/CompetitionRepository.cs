using DataAccess.Concrete;
using DataAccess.Models;
using Football.Crosscutting.ViewModels.Competition;
using Football.DataAccess.Interface;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Football.DataAccess.Concrete
{
    public class CompetitionRepository : EFRepositoryBase, ICompetitionRepository
    {
        public CompetitionRepository(c__database_futbol_mdfContext context) : base(context)
        {
        }
        
        public async Task<List<Competition>> GetCompetitions(int? teamId =null, string season=null)
        {
            if (teamId == null)
            {
                var ey = _context.Competicion.ToAsyncEnumerable();

                if (!string.IsNullOrEmpty(season))
                {
                    ey = ey.Where(x => x.Temporada == season);
                }

                return await ey.Select(x=>new Competition()
                {
                    Id = x.CodCompeticion,
                    Name = x.Nombre,
                    Season = x.Temporada
                }).ToList();
            }

            return await _context.EquiposParticipan.Include(x => x.Competicion)
            .Where(x => x.CodEquipo == teamId)
            .Select(x => new Competition{
                Name = x.Competicion.Nombre,
                Season = x.Competicion.Temporada,
                Id = x.CodCompeticion
            }).ToListAsync();
            
        }
    }
}
