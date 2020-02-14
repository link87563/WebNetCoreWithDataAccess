using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSampleWithDataAccess.DataAccess.Base;
using WebSampleWithDataAccess.DataAccess.Interface;
using WebSampleWithDataAccess.Entities;

namespace WebSampleWithDataAccess.DataAccess.Implement
{
    public class UserAccess : IUserAccess
    {
        public UserContext _context;

        public UserAccess(UserContext context)
        {
            _context = context;
        }

        // Create new data
        public bool CreateUser(User model)
        {
            model.CreatedDate = DateTime.Now;    
            _context.User.Add(model);
            return _context.SaveChanges() > 0;
        }

        // Searching all data
        public IEnumerable<User> GetUsers()
        {
            return _context.User.ToList();
        }

        // Searching data by id
        public User GetUserByID(string id)
        {
            return _context.User.SingleOrDefault(s => s.UserId == id);
        }

        // According id then update data
        public bool UpdateUser(User model)
        {
            model.UpdatedDate = DateTime.Now;
            _context.User.Update(model);
            return _context.SaveChanges() > 0;
        }

        // According id then update name
        public bool UpdateNameByID(string id, string name)
        {
            var state = false;
            var user = _context.User.SingleOrDefault(s => s.UserId == id);

            if (user != null)
            {
                user.UserName = name;
                user.UpdatedDate = DateTime.Now;
                state = _context.SaveChanges() > 0;
            }

            return state;
        }

        // According id then change user status
        public bool DeleteUserByID(string id)
        {
            var state = false;
            var user = _context.User.SingleOrDefault(s => s.UserId == id);
            if (user != null)
            {
                user.IsActive = "N";
                user.UpdatedDate = DateTime.Now;
                state = _context.SaveChanges() > 0;
            }
            // Really want to delete a data
            //_context.User.Remove(user);
            return state;
        }

        // Search user data by id and password
        public User LoginUser(User model)
        {
            return _context.User.SingleOrDefault(s => s.UserId == model.UserId && s.UserPassword == model.UserPassword);
        }

        // Search user data by token
        public User GetUserByToken(User model)
        {
            return _context.User.SingleOrDefault(s => s.UserToken == model.UserToken);
        }
    }
}
