using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSampleWithDataAccess.Controllers;
using WebSampleWithDataAccess.DataAccess.Interface;
using WebSampleWithDataAccess.Entities;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private IUserAccess _userAccess;
        private List<User> _users;

        public void SetUp()
        {
            _userAccess = Substitute.For<IUserAccess>();

            _users = new List<User>()
            {
                new User{
                    RowNum =11,
                    UserId ="sss",
                    UserName ="SSS",
                    IsActive ="Y",
                    CreatedDate =DateTime.Now,
                    UpdatedDate =DateTime.Now
                },
            };

            _userAccess.GetUsers().Returns(_users);
        }

        [Test]
        public void TestMethod1()
        {

        }
    }
}
