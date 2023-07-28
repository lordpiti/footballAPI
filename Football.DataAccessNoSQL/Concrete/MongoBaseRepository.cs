namespace Spacehive.DataCollection.DataAccess.Concrete
{
    using MongoDB.Driver;
    using Microsoft.Extensions.Options;
    using Crosscutting.ViewModels;
    using Football.DataAccessNoSQL.Interface;

    public class MongoBaseRepository
    {
        protected readonly IMongoContext _mongoContext;

        public MongoBaseRepository(IMongoContext context)
        {
            _mongoContext = context;
        }
    }
}
