using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSampleWithDataAccess.DataAccess.Base;
using WebSampleWithDataAccess.DataAccess.Interface;
using WebSampleWithDataAccess.Entities;

namespace WebSampleWithDataAccess.Service
{
    public class UserService : IUserService
    {
        IUserAccess _userAccess;

        public UserService(IUserAccess userAccess)
        {
            _userAccess = userAccess;
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IResult Create(User model)
        {
            var result = new Result();
            try
            {
                if (string.IsNullOrEmpty(model.UserId.Trim()))
                {
                    result.Message = "Please input ID";
                }

                bool status = _userAccess.CreateUser(model);

                if (status)
                {
                    result.Success("Create success");
                }
                else
                {
                    result.Fail("Create fail");
                }
            }
            catch (Exception ex)
            {
                result.Fail(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Search all user
        /// </summary>
        /// <returns></returns>
        public IResult Gets()
        {
            var result = new Result();
            try
            {
                var data = _userAccess.GetUsers();

                if (data != null)
                {
                    result.Data = data;
                    result.Success();
                }
                else
                {
                    result.Success("No Data");
                }
            }
            catch (Exception ex)
            {
                result.Fail(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Search user by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResult Get(string id)
        {
            var result = new Result();
            try
            {
                if (string.IsNullOrEmpty(id.Trim()))
                {
                    return result.Fail("The id can't be empty");
                }

                var data = _userAccess.GetUserByID(id);

                if (data != null)
                {
                    result.Data = data;
                    result.Success();
                }
                else
                {
                    result.Success("No Data");
                }
            }
            catch (Exception ex)
            {
                result.Fail(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// According user id then update data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IResult Update(User model)
        {
            var result = new Result();
            try
            {
                if (string.IsNullOrEmpty(model.UserName.Trim()))
                {
                    return result.Fail("The name can't be empty");
                }

                bool data = _userAccess.UpdateUser(model);

                if (data)
                {
                    result.Success("Update success");
                }
                else
                {
                    result.Fail("Update fail");
                }
            }
            catch (Exception ex)
            {
                result.Fail(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// According user id then update user name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IResult UpdateName(string id, string name)
        {
            var result = new Result();
            try
            {
                if (string.IsNullOrEmpty(name.Trim()))
                {
                    return result.Fail("The name can't be empty");
                }

                bool date = _userAccess.UpdateNameByID(id, name);

                if (date)
                {
                    result.Success("Update success");
                }
                else
                {
                    result.Fail("Update fail");
                }
            }
            catch (Exception ex)
            {
                result.Fail(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// According user id then remove data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResult Delete(string id)
        {
            var result = new Result();
            try
            {
                if (string.IsNullOrEmpty(id.Trim()))
                {
                    return result.Fail("The id can't be empty");
                }

                bool data = _userAccess.DeleteUserByID(id);

                if (data)
                {
                    result.Success("Delete success");
                }
                else
                {
                    result.Fail("Delete fail");
                }
            }
            catch (Exception ex)
            {
                result.Fail(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Search Login user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public User LoginUser(User model)
        {
            User result = new User();
            try
            {
                if (string.IsNullOrEmpty(model.UserId))
                {
                    throw new Exception("User id can't be empty!");
                }

                if (string.IsNullOrEmpty(model.UserPassword))
                {
                    throw new Exception("User password can't be empty!");
                }

                result = _userAccess.LoginUser(model);
            }
            catch (Exception)
            {
                throw new Exception("ERROR");
            }
            return result;
        }

        public User GetUserByToken(User model)
        {
            User result = new User();
            try
            {
                if (string.IsNullOrEmpty(model.UserToken))
                {
                    throw new Exception("User token can't be empty!");
                }
                result = _userAccess.GetUserByToken(model);
            }
            catch (Exception)
            {
                throw new Exception("ERROR");
            }
            return result;
        }
    }
}
