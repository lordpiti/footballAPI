using Football.Crosscutting.ViewModels.User;
using Football.DataAccessNoSQL.Constants;
using Football.DataAccessNoSQL.Interface;
using MongoDB.Driver;
using Newtonsoft.Json;
using Spacehive.DataCollection.DataAccess.Concrete;
using System.Threading.Tasks;

namespace Football.DataAccessNoSQL.Concrete
{
    public class UserRepository: MongoBaseRepository<UserData>, IUserRepository
    {
        public UserRepository(IMongoDatabase mongoDatabase) : base(mongoDatabase, MongoCollections.Users)
        {

        }

        //public List<UserData> UserList()
        //{
        //    #region using bsondocuments and deserialising them

        //    //IMongoCollection<BsonDocument> collection = _mongoDb.GetCollection<BsonDocument>("projectFollowedSurvey"); // initialize to the collection to read from

        //    //var lista = new List<object>();

        //    //var cursor = collection.Find(new BsonDocument());//.ToCursor();

        //    //foreach (var document in cursor.ToEnumerable())
        //    //{
        //    //    var bu = BsonSerializer.Deserialize<object>(document);

        //    //    lista.Add(bu);

        //    //    #region old shit

        //    //    //using (var stringWriter = new StringWriter())
        //    //    //using (var jsonWriter = new JsonWriter(stringWriter))
        //    //    //{
        //    //    //    var context = BsonSerializationContext.CreateRoot(jsonWriter);
        //    //    //    collection.DocumentSerializer.Serialize(context, document);
        //    //    //    var line = stringWriter.ToString();

        //    //    //    lista.Add(line);
        //    //    //}

        //    //    #endregion
        //    //}

        //    #endregion

        //    var allUsers = Collection.AsQueryable().ToList();

        //    return allUsers;
        //}

        public async Task<UserData> FindOrCreateUser(LoginResponse loginResponse)
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            var user = await Collection.Find(x => x.Email == loginResponse.Email && x.AuthenticationType == loginResponse.AuthenticationType).FirstOrDefaultAsync();

            if (user != null)
            {
                return user;
            }
            else
            {
                var newUser = new UserData()
                {
                    Email = loginResponse.Email,
                    UserId = loginResponse.Id,
                    Name = loginResponse.Name,
                    AuthenticationType = loginResponse.AuthenticationType,
                    Role = loginResponse.Role,
                    Token = loginResponse.Token
                };

                //var collection = _mongoContext.Database.GetCollection<UserData>("users");

                Collection.InsertOne(newUser);

                return newUser;
            }
        }

        //public async Task<UserData> FindUserByToken(string token)
        //{
        //    var user = await Collection.Find(x => x.Token == token).FirstOrDefaultAsync();

        //    return user;
        //}
    }
}
