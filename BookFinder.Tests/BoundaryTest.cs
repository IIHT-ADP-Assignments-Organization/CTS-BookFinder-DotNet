using BookFinder.BusinessLayer.Interfaces;
using BookFinder.BusinessLayer.Services;
using BookFinder.DataLayer.NHibernate;
using BookFinder.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace BookFinder.Tests
{
    public  class BoundaryTest
    {
        private readonly IUserServices _service;
        private readonly IMapperSession _session = Substitute.For<IMapperSession>();

        public BoundaryTest()
        {
            _service = new UserServices(_session);
        }

        Random random = new Random();


        [Fact]
        public void BoundaryTest_ForUserName_Length()
        {
            //Arrange

            User user = new User()
            {
                UserId = random.Next(100, 10000000),
                UserName = "Mary",
                Email = "John@gamail.com",
                Password = "123456789",
            };
            var MinLength = 3;
            var MaxLength = 50;

            //Action
            var actualLength = user.UserName.Length;
            var getregisteredUser = _service.GetUserById(user.UserId);
            //Assert
            Assert.InRange(getregisteredUser.UserName.Length, MinLength, MaxLength);
            Assert.InRange(actualLength, MinLength, MaxLength);
        }
        [Fact]
        public void Boundary_Testfor_ValidUserName()
        {
            //Action
            var user = new User()
            {
                UserId = random.Next(100, 10000000),
                UserName = "Rose",
                Email = "abc@gmail.com",
                Password = "1234"
            };
            var getregisteredUser = _service.GetUserById(user.UserId);
           bool getisUserName = Regex.IsMatch(getregisteredUser.UserName, @"^[a-zA-Z0-9]{4,10}$", RegexOptions.IgnoreCase);
            bool isUserName = Regex.IsMatch(user.UserName, @"^[a-zA-Z0-9]{4,10}$", RegexOptions.IgnoreCase);
            //Assert
            Assert.True(isUserName);
           Assert.True(getisUserName);
        }

        [Fact]
        public void BoundaryTest_ForPassword_Length()
        {

            User user = new User()
            {
                UserId = random.Next(100, 10000000),
                UserName = "Mary",
                Email = "John@gamail.com",
                Password = "123456789",
            };
            var MinLength = 8;
            var MaxLength = 25;

            //Action
            var actualLength = user.Password.Length;
            var getregisteredUser = _service.GetUserById(user.UserId);
            //Assert
            Assert.InRange(getregisteredUser.Password.Length, MinLength, MaxLength);
            Assert.InRange(actualLength, MinLength, MaxLength);
        }

        [Fact]
        public void BoundaryTest_ValidISBNLength()
        {

            Book book = new Book()
            {
                BookId = 1,
                Title = "Malgudi Days",
                Authors = "R.K. Narayan",
                ISBN = 9780143039655,
                PublishedDate = new DateTime(1943, 03, 09),
                CoverPageURL = "https://en.wikipedia.org/wiki/Malgudi_Days_(short_story_collection)"
            };
            var MinLength = 13;
            var MaxLength = 13;

            //Action
            var actualLength = book.ISBN.ToString().Length;
            var getbook = _service.BookDetails(book.BookId);
            //Assert
            Assert.InRange(getbook.ISBN.ToString().Length, MinLength, MaxLength);
            Assert.InRange(actualLength, MinLength, MaxLength);
        }


        [Fact]
        public void Boundary_Testfor_ValidEmail()
        {
            //Action
            var user = new User()
            {
                UserId = random.Next(100, 10000000),
                UserName = "Rose",
                Email = "abc@gmail.com",
                Password = "1234"
            };
            var getregisteredUser = _service.GetUserById(user.UserId);

            bool CheckEmail = Regex.IsMatch(getregisteredUser.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            bool isEmail = Regex.IsMatch(user.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            //Assert
            Assert.True(isEmail);
            Assert.True(CheckEmail);
        }
    }
}
