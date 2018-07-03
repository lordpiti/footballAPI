using Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Reports;
using Football.DataAccessNoSQL.Interface;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Spacehive.DataCollection.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccessNoSQL.Concrete
{
    public class ReportNoSQLRepository : MongoBaseRepository, IReportNoSQLRepository
    {
        public ReportNoSQLRepository(IOptions<AppSettings> settings) : base(settings)
        {

        }

        public void CreateReport(ReportData reportData)
        {
            var collection = _mongoDb.GetCollection<BsonDocument>("matches");

            if (reportData != null)
            {
                collection.DeleteOne(Builders<BsonDocument>.Filter.Eq("MatchId", reportData.MatchId));
            }

            var document = reportData.ToBsonDocument();

            collection.InsertOne(document);
        }

        public ReportData GetReportSnapshot(int matchId)
        {
            var matchSnapshots = _mongoDb.GetCollection<ReportData>("matches").AsQueryable().ToList();

            var data = matchSnapshots.FirstOrDefault(x => x.MatchId == matchId);

            return data;
        }
    }
}
