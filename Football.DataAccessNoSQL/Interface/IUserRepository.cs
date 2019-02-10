using Football.Crosscutting.Enums;
using Football.Crosscutting.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DataAccessNoSQL.Interface
{
    public interface IUserRepository
    {
        List<UserData> UserList();

        UserData FindOrCreateUser(LoginResponse facebookResponse);

        UserData FindUserByFacebookUserId(LoginTypeEnum authenticationType, string facebookUserId);

        UserData FindUserByToken(string token);
    }
}
