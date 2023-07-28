using Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Reports;
using Football.Crosscutting.ViewModels.User;
using Football.DataAccessNoSQL.Interface;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Football.DataAccessNoSQL.Concrete
{
    public class MongoContext : IMongoContext
    {
        private IMongoCollection<UserData> _users;
        private IMongoCollection<ReportData> _reportDatas;

        public MongoContext(IMongoClient mongoClient)
        {
            Client = mongoClient;
        }

        public IMongoClient Client { get; }
        public IMongoDatabase Database => Client.GetDatabase("haha");
        public IMongoCollection<UserData> Users => _users ??= Database.GetCollection<UserData>("users");
        public IMongoCollection<ReportData> ReportDatas => _reportDatas ??= Database.GetCollection<ReportData>("matches");
    }
}
