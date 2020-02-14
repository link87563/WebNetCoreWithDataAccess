using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSampleWithDataAccess.DataAccess.Interface;
using WebSampleWithDataAccess.Entities;

namespace WebSampleWithDataAccess.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private ITokenManager _tokenManager;
        private IUserService _userService;

        public TokenController(ITokenManager tokenManager,
            IUserService userService)
        {
            _tokenManager = tokenManager;
            _userService = userService;
        }

        /// <summary>
        /// Sign in creat a Token to user
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [Route(""), HttpPost]
        public IActionResult SignIn(UserCondition condition)
        {
            var model = _userService.LoginUser(
                new Entities.User
                {
                    UserId = condition.UserId,
                    UserPassword = condition.UserPassword
                });

            if (model == null)
            {
                throw new Exception("No data");
            }

            var token = _tokenManager.Create(model);

            model.UserToken = token.RefreshToken;

            var result = _userService.Update(model);

            if (result.Success == false)
            {
                throw new Exception("Please contact MIS");
            }

            return Ok(token);
        }

        /// <summary>
        /// Get new token to user
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        [Route("refresh"), HttpPost]
        public IActionResult Refresh(string refreshToken)
        {
            var model = _userService.GetUserByToken(new Entities.User { UserToken = refreshToken });

            if (model == null)
            {
                throw new Exception("No data");
            }

            var token = _tokenManager.Create(model);

            model.UserToken = token.RefreshToken;
            var result = _userService.Update(model);

            return Ok(token);
        }
        
        /// <summary>
        /// verification token
        /// </summary>
        /// <returns></returns>
        [Route("isAuthenticated"), HttpPost]
        public bool IsAuthenticated()
        {
            bool result = false;
            var user = _tokenManager.GetUser();

            if (user == null)
            {
                return result;
            }
            return result = true;
        }
    }
}