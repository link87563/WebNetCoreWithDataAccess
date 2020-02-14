using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSampleWithDataAccess.Entities;

namespace WebSampleWithDataAccess.DataAccess.Interface
{
    public interface IUserService
    {
        IResult Create(User model);
        IResult Gets();
        IResult Get(string id);
        IResult Update(User model);
        IResult UpdateName(string id, string name);
        IResult Delete(string id);
        User LoginUser(User model);
        User GetUserByToken(User model);
    }
}
