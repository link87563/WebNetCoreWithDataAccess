using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSampleWithDataAccess.Entities;

namespace WebSampleWithDataAccess.DataAccess.Interface
{
    public interface IUserAccess
    {
        bool CreateUser(User model);
        IEnumerable<User> GetUsers();
        User GetUserByID(string id);
        bool UpdateUser(User model);
        bool UpdateNameByID(string id, string name);
        bool DeleteUserByID(string id);
        User LoginUser(User model);
        User GetUserByToken(User model);
    }
}
