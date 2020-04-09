using BookFinder.BusinessLayer.Interfaces;
using BookFinder.BusinessLayer.Services;
using BookFinder.DataLayer.NHibernate;
using BookFinder.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookFinder.Tests
{
   public class FunctionalTests
    {
        private readonly IUserServices _service;
        private readonly IMapperSession _session = Substitute.For<IMapperSession>();

        public FunctionalTests()
        {
            _service = new UserServices(_session);
        }


        [Fact]
        public void TestFor_ValidRegister()
        {
            //Arrange
            User user = new User()
            {
                UserId = 100,
                UserName = "Rose",
                Email = "abc@gmail.com",
                Password = "1234"
            };
            //Action
            var registeredUser = _service.Register(user.UserName, user.Email,user.Password);
            var getregisteredUser = _service.GetUserById(user.UserId);
            //Assert
            Assert.Equal(getregisteredUser, registeredUser);
        }

        [Fact]
        public void Test_For_Valid_Login()
        {
            //Arrange
            //Arrange
            User user = new User()
            {
                UserId = 100,
                UserName = "Rose",
                Email = "abc@gmail.com",
                Password = "1234"
            };
            //Action
            var loggedUser = _service.Login(user.UserName, user.Password);
            var getregisteredUser = _service.GetUserById(user.UserId);
            //Assert
            Assert.Equal(getregisteredUser, loggedUser);
        }
        
        [Fact]
        public void TestFor_ValidGetBookDetails()
        {
            //Arrange
            //Arrange
            Book book = new Book()
            {
                BookId = 100,
                Title = "Malgudi Days",
                Authors = "R.K. Narayan",
                ISBN = 98765543233445,
                PublishedDate = new DateTime(1943, 03, 09),
                CoverPageURL= "https://en.wikipedia.org/wiki/Malgudi_Days_(short_story_collection)"
            };
            //Action
            var getbook = _service.BookDetails(book.BookId);
            
            //Assert
            Assert.NotNull(getbook);
            Assert.Equal(book, getbook);
        }

        [Fact]
        public void TestFor_SearchBook()
        {
            //Arrange
            //Arrange
            Book book = new Book()
            {
                BookId = 1,
                Title = "Malgudi Days",
                Authors = "R.K. Narayan",
                ISBN = 9780143039655,
                PublishedDate = new DateTime(1943, 03, 09),
                CoverPageURL = "https://en.wikipedia.org/wiki/Malgudi_Days_(short_story_collection)"
            };
            //Action
            var getbookList = _service.SearchBook(book.ISBN, book.Title,book.Authors);

            //Assert
            Assert.NotNull(getbookList);
            Assert.NotEmpty(getbookList);
        }
        [Fact]
        public void TestFor_ValidGetUser()
        {
            //Arrange
            //Arrange
            User user = new User()
            {
                UserId = 100,
                UserName = "Rose",
                Email = "abc@gmail.com",
                Password = "1234"
            };
            //Action
            var getuser = _service.GetUserById(user.UserId);

            //Assert
            Assert.NotNull(getuser);
            Assert.Equal(user, getuser);
        }
    }
}
