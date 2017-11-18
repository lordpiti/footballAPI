using Football.Crosscutting.Enums;
using Football.Crosscutting.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Interface
{
    public interface IUserService
    {
        List<Object> UserList();

        Task<LoginResponse> Login(LoginTypeEnum loginType, string userId, string authToken, bool login = true);
    }
}
