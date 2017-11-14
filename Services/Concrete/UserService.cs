using Football.Crosscutting.ViewModels.User;
using Football.DataAccessNoSQL.Interface;
using Football.Services.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<FacebookResponse> Login(string userId, string accessToken, bool login = true)
        {
            var me = new FacebookResponse();
            HttpClient client = new HttpClient();

            string verifyTokenEndPoint = string.Format("https://graph.facebook.com/me?access_token={0}&fields=email,name", accessToken);
            string verifyAppEndpoint = string.Format("https://graph.facebook.com/app?access_token={0}", accessToken);

            Uri uri = new Uri(verifyTokenEndPoint);
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                dynamic userObj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                uri = new Uri(verifyAppEndpoint);
                response = await client.GetAsync(uri);
                content = await response.Content.ReadAsStringAsync();
                dynamic appObj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);


                //if (appObj["id"] == socialConfig.Facebook.AppId)
                //{
                    //token is from our App

                    me.Id = userObj["id"];
                    me.Email = userObj["email"];
                    me.Name = userObj["name"];
                    me.IsVerified = true;
                //}
                if (login)
                {
                    _userRepository.FindOrCreateUser(me);
                }
                else
                {
                    var user = _userRepository.FindUserByFacebookUserId(me.Id);

                    if (user!=null && user.FacebookUserId == me.Id)
                    {
                        return me;
                    }
                    else
                    {
                        return null;
                    }
                }
                

                return me;
            }
            return null;
        }

        public List<object> UserList()
        {
            return _userRepository.UserList();
        }
    }
}
