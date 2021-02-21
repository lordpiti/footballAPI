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
    public abstract class EFRepositoryBase<TEntity>: IRepositoryBase<TEntity> where TEntity:BaseEntity
    {
        protected readonly FootballContext _context;

        public EFRepositoryBase(FootballContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> results = _context.Set<TEntity>();

            if (predicate != null)
            {
                results = results.Where(predicate);
            }

            return results;
        }

        public Task<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public void Delete(TEntity item)
        {
            _context.Remove(item);
        }

        public void Add(TEntity item)
        {
            _context.Add(item);
        }

        public async Task AddAsync(TEntity item)
        {
            await _context.AddAsync(item);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
    
}
