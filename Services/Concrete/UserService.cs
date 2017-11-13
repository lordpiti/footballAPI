using Football.DataAccessNoSQL.Interface;
using Football.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public List<object> UserList()
        {
            return _userRepository.UserList();
        }
    }
}
