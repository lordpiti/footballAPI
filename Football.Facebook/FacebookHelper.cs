using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Facebook
{
    public static class FacebookHelper
    {
        public static Object Test(string accessToken)
        {
            var client = new FacebookClient(accessToken);
            dynamic result = client.Get("me", new { fields = "name,id" });
            string name = result.name;
            string id = result.id;

            return new { name= name, id = id };
        }
    }
}
