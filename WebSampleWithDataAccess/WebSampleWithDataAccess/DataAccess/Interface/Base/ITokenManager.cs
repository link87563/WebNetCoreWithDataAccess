using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSampleWithDataAccess.Entities;

namespace WebSampleWithDataAccess.DataAccess.Interface
{
    public interface ITokenManager
    {
        Entities.Token Create(User model);

        IResult GetUser();
    }
}
