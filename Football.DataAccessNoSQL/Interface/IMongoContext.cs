using Football.Crosscutting.ViewModels.Reports;
using Football.Crosscutting.ViewModels.User;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Football.DataAccessNoSQL.Interface
{

    public interface IMongoContext
    {
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }
        IMongoCollection<UserData> Users { get; }
        IMongoCollection<ReportData> ReportDatas { get; }
    }
}
