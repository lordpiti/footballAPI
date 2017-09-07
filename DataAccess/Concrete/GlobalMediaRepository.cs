using DataAccess.Concrete;
using DataAccess.Models;
using Football.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DataAccess.Concrete
{
    public class GlobalMediaRepository : EFRepositoryBase, IGlobalMediaRepository
    {
        public GlobalMediaRepository(c__database_futbol_mdfContext context) : base(context)
        {
        }


    }
}
