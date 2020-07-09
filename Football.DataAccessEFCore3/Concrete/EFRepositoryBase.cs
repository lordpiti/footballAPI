using Football.DataAccessEFCore3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DataAccessEFCore3.Concrete
{
    public abstract class EFRepositoryBase
    {
        protected readonly FootballContext _context;

        public EFRepositoryBase(FootballContext context)
        {
            _context = context;
        }
    }
    
}
