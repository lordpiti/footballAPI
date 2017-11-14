using Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.User;
using Football.DataAccessNoSQL.Interface;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Spacehive.DataCollection.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football.DataAccessNoSQL.Concrete
{
    public class UserRepository: MongoBaseRepository, IUserRepository
    {
        public UserRepository(IOptions<AppSettings> settings) : base(settings)
        {

        }

        public List<Object> UserList()
        {
            #region using bsondocuments and deserialising them

            //IMongoCollection<BsonDocument> collection = _mongoDb.GetCollection<BsonDocument>("projectFollowedSurvey"); // initialize to the collection to read from

            //var lista = new List<object>();

            //var cursor = collection.Find(new BsonDocument());//.ToCursor();

            //foreach (var document in cursor.ToEnumerable())
            //{
            //    var bu = BsonSerializer.Deserialize<object>(document);

            //    lista.Add(bu);

            //    #region old shit

            //    //using (var stringWriter = new StringWriter())
            //    //using (var jsonWriter = new JsonWriter(stringWriter))
            //    //{
            //    //    var context = BsonSerializationContext.CreateRoot(jsonWriter);
            //    //    collection.DocumentSerializer.Serialize(context, document);
            //    //    var line = stringWriter.ToString();

            //    //    lista.Add(line);
            //    //}

            //    #endregion
            //}

            #endregion

            var allUsers = _mongoDb.GetCollection<Object>("users").AsQueryable().ToList();

            return allUsers;
        }

        public UserData FindOrCreateUser(FacebookResponse facebookResponse)
        {
            //var document = BsonSerializer.Deserialize<BsonDocument>(item);

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            var users = _mongoDb.GetCollection<UserData>("users").AsQueryable().ToList();

            var user = users.FirstOrDefault(x => x.Email == facebookResponse.Email);

            if (user != null)
            {
                return user;
            }
            else
            {
                var newUser = new UserData()
                {
                    Email = facebookResponse.Email,
                    FacebookUserId = facebookResponse.Id,
                    Name = facebookResponse.Name
                };

                var collection = _mongoDb.GetCollection<BsonDocument>("users");

                var userDocument = newUser.ToBsonDocument();

                collection.InsertOne(userDocument);

                return newUser;
            }
        }

        public UserData FindUserByFacebookUserId(string facebookUserId)
        {
            var users = _mongoDb.GetCollection<UserData>("users").AsQueryable().ToList();

            var user = users.FirstOrDefault(x => x.FacebookUserId == facebookUserId);

            return user;
        }
    }
}
