using BookFinder.BusinessLayer.Interfaces;
using BookFinder.BusinessLayer.Services;
using BookFinder.DataLayer.NHibernate;
using BookFinder.Entities;
using BookFinder.Tests.Exceptions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookFinder.Tests
{
   public class ExceptionalTest
    {
        private readonly IUserServices _service;
        private readonly IMapperSession _session = Substitute.For<IMapperSession>();

        public ExceptionalTest()
        {
            _service = new UserServices(_session);
        }

        Random random = new Random();

        [Fact]
        public void ExceptionTestFor_UserNotFound()
        {
            //Assert
            User user = new User()
            {
                UserId = random.Next( 100,10000000),
                UserName = "Mary",
                Email = "John@gamail.com",
                Password = "123456789",
            };
            var ex = Assert.Throws<UserNotFoundException>(() => _service.Login(user.UserName,user.Password));
            Assert.Equal("User Not Found ", ex.Messages);
        }
        [Fact]
        public void ExceptionTestFor_ValidRegistration()
        {
            User user = new User()
            {
                UserId = random.Next(100, 10000000),
                UserName = "Mary",
                Email = "John@gamail.com",
                Password = "123456789",
            };
            //Action
            //Assert
            var ex = Assert.Throws<UserExistException>(() => _service.Register(user.UserName, user.Email, user.Password));
            Assert.Equal("Already have an Account please login", ex.Messages);
        }

        [Fact]
        public void ExceptionTestFor_ValidUserName_InvalidPassword()
        {
            User user = new User()
            {
                UserId = random.Next(100, 10000000),
                UserName = "Mary",
                Email = "John@gamail.com",
                Password = "12356789",
            };
            //Assert
            var ex = Assert.Throws<InvalidCredentialsExceptions>(() => _service.Login(user.UserName, user.Password));
            Assert.Equal("Please enter valid usename & password", ex.Messages);
        }

        [Fact]
        public void ExceptionTestFor_InvalidUserName_validPassword()
        {
            //Action
            User user = new User()
            {
                UserId = random.Next(100, 10000000),
                UserName = "abc",
                Email = "hn@gamail.com",
                Password = "123789",
            };
            //Assert
            var ex = Assert.Throws<InvalidCredentialsExceptions>(() => _service.Login(user.UserName, user.Password));
            Assert.Equal("Please enter valid usename & password", ex.Messages);
        }
    }
}
