using Football.Crosscutting.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DataAccessNoSQL.Interface
{
    public interface IUserRepository
    {
        List<Object> UserList();

        UserData FindOrCreateUser(FacebookResponse facebookResponse);

        UserData FindUserByFacebookUserId(string facebookUserId);
    }
}
