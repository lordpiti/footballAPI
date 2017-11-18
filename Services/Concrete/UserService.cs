using Football.Crosscutting.Enums;
using Football.Crosscutting.ViewModels.User;
using Football.DataAccessNoSQL.Interface;
using Football.Services.Interface;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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

        public async Task<LoginResponse> Login(LoginTypeEnum loginType, string userId, string accessToken, bool login = true)
        {
            HttpClient client = new HttpClient();
            var me = new LoginResponse();

            if (loginType == LoginTypeEnum.Google)
            {
                #region Google authentication

                //var googleToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6ImY0MzYwNWRlYzY5YjdmN2U1YThiNWY2ZDIzZjM5YTMwYWE1YWY2ZTcifQ.eyJhenAiOiIzNTc4MTMyNjQzOTEtYmM1MWIydTBvaGFlYjZ2NzhrMmIydHByNXBkaTZjMDkuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJhdWQiOiIzNTc4MTMyNjQzOTEtYmM1MWIydTBvaGFlYjZ2NzhrMmIydHByNXBkaTZjMDkuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJzdWIiOiIxMTA4MjY3OTY1NzkyODEwMzcwNzciLCJlbWFpbCI6ImxvcmRwaXRpQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJhdF9oYXNoIjoicUVid2dyS1FaNjdLS3pSMzNRM09tdyIsImlzcyI6ImFjY291bnRzLmdvb2dsZS5jb20iLCJqdGkiOiIxODU4ZTFlMzBmZmU1NGY3YzA0ZDU2ZWE5ZmExZWYzNGQ2YWM0ZmJmIiwiaWF0IjoxNTExMDE4NDI4LCJleHAiOjE1MTEwMjIwMjgsIm5hbWUiOiJQYWJsbyBBbWlsIiwicGljdHVyZSI6Imh0dHBzOi8vbGgzLmdvb2dsZXVzZXJjb250ZW50LmNvbS8tZ2d5OVZEY2Nsb0UvQUFBQUFBQUFBQUkvQUFBQUFBQUFBQUEvQU5RMGtmNG5WYnM1TzZGRnpQRXhRQ0VxVlREM1NJak13dy9zOTYtYy9waG90by5qcGciLCJnaXZlbl9uYW1lIjoiUGFibG8iLCJmYW1pbHlfbmFtZSI6IkFtaWwiLCJsb2NhbGUiOiJlcyJ9.SWU9b9UMNtUjeJ-hVQUd4V6WS7jnr3b2LHhgrEIOhfbQ9CyrSIjVtzP2rCOjZQF9DVDzRAHHewP42FcpDx5Cs_01MRHY3HstSLDfCdrwnVtUeGR1HY_V2dfFAbgE7fjuWvt_is7SnxT5-SUkhI_UqrzQr9OI90x2a4HBiC9jHueJ7y2LaF3ESnrdDxbZowtK8c6clA3ud7s8qNhsJiHUrUAMfU3buOFIoRX9r7YoTXKruOOFSh7g-1EAtCgCEyeOSDG5uB3z8kuB26woy8Cwnvl7RFPHpJrEmJu64DEeK67jr0itVUuh14ynryYA8o-kKYlyjcG3anmfc744mg_XHw";
                
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

                    if (login)
                    {
                        _userRepository.FindOrCreateUser(me);
                    }
                    else
                    {
                        var user = _userRepository.FindUserByFacebookUserId(LoginTypeEnum.Google, me.Id);

                        if (user != null && user.AuthenticationType == LoginTypeEnum.Google && user.UserId == me.Id)
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

                #endregion
            }
            else
            {
                #region Facebook

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
                    me.AuthenticationType = LoginTypeEnum.Facebook;
                    //}
                    if (login)
                    {
                        _userRepository.FindOrCreateUser(me);
                    }
                    else
                    {
                        var user = _userRepository.FindUserByFacebookUserId(LoginTypeEnum.Facebook, me.Id);

                        if (user != null && user.AuthenticationType == LoginTypeEnum.Facebook && user.UserId == me.Id)
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

                #endregion
            }
        }

        public List<object> UserList()
        {
            return _userRepository.UserList();
        }
    }
}
