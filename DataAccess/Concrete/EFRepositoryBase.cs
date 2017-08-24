using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public abstract class EFRepositoryBase
    {
        protected readonly c__database_futbol_mdfContext _context;

        public EFRepositoryBase(c__database_futbol_mdfContext context)
        {
            _context = context;
        }
    }
    
}
