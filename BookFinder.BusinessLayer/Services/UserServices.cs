using BookFinder.BusinessLayer.Interfaces;
using BookFinder.DataLayer.NHibernate;
using BookFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookFinder.BusinessLayer.Services
{
 public class UserServices : IUserServices
    {
        private readonly IMapperSession _session;

        public UserServices(IMapperSession session)
        {
            _session = session;
        }

        public Book BookDetails(int BookId)
        {
            return new Book();
        }

        public User GetUserById(int userId)
        {
            return new User();
        }

        public User Login(string username, string Password)
        {
            return new User();
        }

        public User Register(string username, string email, string Password)
        {
            return new User();
        }

        public List<Book> SearchBook(long ISBN, string Title, string Author)
        {
            return new List<Book>();
        }
    }
}
        