using Football.Crosscutting.Enums;
using Football.Crosscutting.ViewModels.User;
using Football.DataAccessNoSQL.Interface;
using Football.Services.Interface;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public async Task<LoginResponse> Login(LoginTypeEnum loginType, string userId, string accessToken, bool login = true)
        {
            HttpClient client = new HttpClient();
            var me = new LoginResponse();

            if (loginType == LoginTypeEnum.Google)
            {
                #region Google authentication

                if (login)
                {
                    var googleTokenUrl = "https://www.googleapis.com/oauth2/v3/tokeninfo?id_token=";
                    var googleUri = new Uri(googleTokenUrl + accessToken);
                    var responseGoogleToken = await client.GetAsync(googleUri);

                    if (responseGoogleToken.IsSuccessStatusCode)
                    {
                        string contentTOKEN = await responseGoogleToken.Content.ReadAsStringAsync();
                        dynamic tokenObjGoogle = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(contentTOKEN);

                        me.Id = tokenObjGoogle["sub"];
                        me.Email = tokenObjGoogle["email"];
                        me.Name = tokenObjGoogle["name"];
                        me.IsVerified = true;
                        me.AuthenticationType = LoginTypeEnum.Google;
                        me.Role = "User";
                        me.Token = Guid.NewGuid().ToString();

                        var user = _userRepository.FindOrCreateUser(me);
                        me.Role = user.Role;
                        me.Token = user.Token;

                        return me;
                    }
                }
                else
                {
                    var user = _userRepository.FindUserByToken(accessToken);

                    if (user != null && user.AuthenticationType == LoginTypeEnum.Google)
                    {
                        me.Id = user.UserId;
                        me.Email = user.Email;
                        me.Name = user.Name;
                        me.IsVerified = true;
                        me.AuthenticationType = user.AuthenticationType;
                        me.Role = user.Role;
                        me.Token = user.Token;
                        return me;
                    }
                    else
                    {
                        return null;
                    }
                }
   
                return null;

                #endregion
            }
            else
            {
                #region Facebook

                if (login)
                {
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

                        me.Id = userObj["id"];
                        me.Email = userObj["email"];
                        me.Name = userObj["name"];
                        me.IsVerified = true;
                        me.AuthenticationType = LoginTypeEnum.Facebook;
                        me.Role = "User";
                        me.Token = Guid.NewGuid().ToString();

                        var userData = _userRepository.FindOrCreateUser(me);
                        me.Role = userData.Role;
                        me.Token = userData.Token;

                        return me;
                    }
                    return null;
                }
                else
                {
                    var user = _userRepository.FindUserByToken(accessToken);

                    if (user != null && user.AuthenticationType == LoginTypeEnum.Facebook)
                    {
                        me.Role = user.Role;
                        me.Token = user.Token;
                        return me;
                    }
                    else
                    {
                        return null;
                    }
                }

                #endregion
            }
        }

        public List<object> UserList()
        {
            return _userRepository.UserList();
        }

        public object TryApiCall(string locationIdentifier, string sortType, int index, string tenure)
        {
            HttpClient qclient = new HttpClient();
            try
            {
                locationIdentifier = locationIdentifier.Replace("^", "%5E");

                var originalUrl = @"http://www.rightmove.co.uk/api/";

                var requestUrl = @"_search?locationIdentifier={0}&sortType={1}&index={2}&viewType=LIST&channel={3}&areaSizeUnit=sqft&currencyCode=GBP";

                var formattedRequestUrl = string.Format(requestUrl, locationIdentifier, sortType, index, tenure);

                var client = new RestClient(originalUrl+formattedRequestUrl);

                var request = new RestRequest(formattedRequestUrl, Method.GET);
                IRestResponse response = client.Get(request);
                var content = response.Content;
                return content;
            }
            catch (Exception ex)
            {

            }

            return null;
        }
    }
}
