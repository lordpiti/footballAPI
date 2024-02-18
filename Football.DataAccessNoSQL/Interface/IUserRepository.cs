using Football.Crosscutting.Enums;
using Football.Crosscutting.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccessNoSQL.Interface
{
    public interface IUserRepository : IMongoRepository<UserData> 
    {
        Task<UserData> FindOrCreateUser(LoginResponse facebookResponse);
    }
}
