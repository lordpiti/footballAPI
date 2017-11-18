using Football.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.User
{
    public class LoginResponse
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public bool IsVerified { get; set; }

        public string Name { get; set; }

        public LoginTypeEnum AuthenticationType { get; set; }
    }
}
