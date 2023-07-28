using Football.Crosscutting.ViewModels.Reports;
using Football.DataAccessNoSQL.Interface;
using MongoDB.Driver;
using Spacehive.DataCollection.DataAccess.Concrete;
using System.Threading.Tasks;

namespace Football.DataAccessNoSQL.Concrete
{
    public class ReportNoSQLRepository : MongoBaseRepository, IReportNoSQLRepository
    {
        public ReportNoSQLRepository(IMongoContext context) : base(context)
        {
         
        }

        public async Task CreateReport(ReportData reportData)
        {
            var options = new ReplaceOptions
            {
                IsUpsert = true
            };

            await _mongoContext.ReportDatas.ReplaceOneAsync(x => x.MatchId == reportData.MatchId, reportData, options);

            //var collection = _mongoContext.Database.GetCollection<BsonDocument>("matches");

            //if (reportData != null)
            //{
            //    collection.DeleteOne(Builders<BsonDocument>.Filter.Eq("MatchId", reportData.MatchId));
            //}

            //var document = reportData.ToBsonDocument();

            //collection.InsertOne(document);
        }

        public async Task<ReportData> GetReportSnapshot(int matchId)
        {
            var matchSnapshot = await _mongoContext.ReportDatas.Find(x => x.MatchId == matchId).FirstOrDefaultAsync();

            return matchSnapshot;
        }
    }
}
