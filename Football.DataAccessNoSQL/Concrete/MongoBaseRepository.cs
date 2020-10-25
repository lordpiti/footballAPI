namespace Spacehive.DataCollection.DataAccess.Concrete
{
    using MongoDB.Driver;
    using Microsoft.Extensions.Options;
    using Crosscutting.ViewModels;

    public class MongoBaseRepository
    {
        protected readonly IMongoDatabase _mongoDb;

        public MongoBaseRepository(IOptions<AppSettings> settings)
        {
            var connectionString = settings.Value.MongoConnection;

            var databaseName = "haha";

            var _client = new MongoClient(connectionString);
            var db = _client.GetDatabase(databaseName);

            _mongoDb = db;
        }
    }
}
