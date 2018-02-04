using Football.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.User
{
    public class UserData
    {
        public string Email { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public LoginTypeEnum AuthenticationType { get; set; }

        public string Role { get; set; }
    }
}
