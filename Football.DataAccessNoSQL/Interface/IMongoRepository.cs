using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Football.DataAccessNoSQL.Interface
{
    public interface IMongoRepository<T>
    {
        public Task<T> FindByExpression(Expression<Func<T, bool>> expression);

        public Task<List<T>> FindManyByExpression(Expression<Func<T, bool>> expression);
    }
}
