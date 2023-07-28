using Football.Crosscutting.Enums;
using Football.Crosscutting.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccessNoSQL.Interface
{
    public interface IUserRepository
    {
        List<UserData> UserList();

        Task<UserData> FindOrCreateUser(LoginResponse facebookResponse);

        Task<UserData> FindUserByToken(string token);
    }
}
