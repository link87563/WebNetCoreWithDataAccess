using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSampleWithDataAccess.DataAccess.Interface;

namespace WebSampleWithDataAccess.DataAccess.Base
{
    public class Result : IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public static class ResultExtension
    {
        /// <summary>
        /// return success no message
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Result Success(this Result result)
        {
            return result.Success("");
        }

        /// <summary>
        /// return success status and message
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result Success(this Result result, string message)
        {
            result.Success = true;
            result.Message = message;
            return result;
        }

        /// <summary>
        /// return fail status and message
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result Fail(this Result result, string message)
        {
            result.Success = false;
            result.Message = message;
            return result;
        }
    }
}
