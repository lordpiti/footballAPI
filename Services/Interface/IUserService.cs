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

        Task<FacebookResponse> Login(string userId, string authToken);
    }
}
