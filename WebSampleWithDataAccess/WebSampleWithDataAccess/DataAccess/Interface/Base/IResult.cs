using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSampleWithDataAccess.DataAccess.Interface
{
    public interface IResult
    {
        bool Success { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}
