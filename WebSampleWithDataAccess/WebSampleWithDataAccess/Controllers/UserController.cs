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
    public class UserController : ControllerBase
    {
        private IUserService _userService;  

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route(""), HttpPost]
        public IActionResult Create(User model)
        {
            return Ok(_userService.Create(model));
        }

        /// <summary>
        /// Search all user
        /// </summary>
        /// <returns></returns>
        [Route(""), HttpGet]
        public IActionResult Gets()
        {
            return Ok(_userService.Gets());
        }

        /// <summary>
        /// Search user by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}"), HttpGet]
        public IActionResult Get(string id)
        {
            return Ok(_userService.Get(id));
        }

        /// <summary>
        /// According user id then update data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route(""), HttpPut]
        public IActionResult Update(User user)
        {
            return Ok(_userService.Update(user));
        }

        /// <summary>
        /// According user id then update user name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("{id}/{name}"), HttpPut]
        public IActionResult UpdateName(string id, string name)
        {
            return Ok(_userService.UpdateName(id, name));
        }

        /// <summary>
        /// According user id then remove data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}"), HttpDelete]
        public IActionResult Delete(string id)
        {
            return Ok(_userService.Delete(id));
        }
    }
}