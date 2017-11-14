using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.User
{
    public class FacebookResponse
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public bool IsVerified { get; set; }

        public string Name { get; set; }
    }
}
