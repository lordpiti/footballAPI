using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DataAccessNoSQL.Interface
{
    public interface IUserRepository
    {
        List<Object> UserList();
    }
}
