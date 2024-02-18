namespace Spacehive.DataCollection.DataAccess.Concrete
{
    using Football.DataAccessNoSQL.Interface;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using System;

    public class MongoBaseRepository<T>
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly string _collectionName;

        protected IMongoCollection<T> Collection => _mongoDatabase.GetCollection<T>(_collectionName);

        public MongoBaseRepository(IMongoDatabase mongoDatabase, string collectionName)
        {
            _mongoDatabase = mongoDatabase;
            _collectionName = collectionName;
        }

        public async Task<T> FindByExpression(Expression<Func<T, bool>> expression)
        {
            return await Collection.FindAsync(expression).Result.FirstOrDefaultAsync();
        }

        public async Task<List<T>> FindManyByExpression(Expression<Func<T, bool>> expression)
        {
            return await Collection.FindAsync(expression).Result.ToListAsync();
        }
    }
}
