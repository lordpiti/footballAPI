using Football.DataAccessEFCore3.Interface;
using Football.DataAccessEFCore3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccessEFCore3.Concrete
{
    public class FootballUnitOfWork : IFootballUnitOfWork
    {
        private readonly FootballContext _context;

        public FootballUnitOfWork(FootballContext context)
        {
            _context = context;
            // check if the context is shared, otherwise inject context once here and create repositories individually passing it in the constructor
            this.CompetitionRepository = new CompetitionRepository(_context);
            this.TeamRepository = new TeamRepository(_context);
            this.GlobalMediaRepository = new GlobalMediaRepository(_context);
        }

        public ICompetitionRepository CompetitionRepository { get; set; }

        public IGlobalMediaRepository GlobalMediaRepository { get; set; }

        public ITeamRepository TeamRepository { get; set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
