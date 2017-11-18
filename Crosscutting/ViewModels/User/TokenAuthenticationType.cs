using Football.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.User
{
    public class TokenAuthenticationType
    {
        public string Token { get; set; }

        public LoginTypeEnum AuthenticationType { get; set; }
    }
}
