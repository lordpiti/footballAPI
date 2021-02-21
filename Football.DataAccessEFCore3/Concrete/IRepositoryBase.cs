using Football.DataAccessEFCore3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccessEFCore3.Concrete
{
    public interface IRepositoryBase<T> where T:BaseEntity
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);

        Task<T> FindByCondition(Expression<Func<T, bool>> predicate);

        int Commit();

        Task<int> CommitAsync();
    }
}
