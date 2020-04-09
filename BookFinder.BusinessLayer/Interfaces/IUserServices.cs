using BookFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookFinder.BusinessLayer.Interfaces
{
  public  interface IUserServices
    {
       User Register(string username,string email, string Password);
       User Login(string username, string Password);
       List<Book> SearchBook(long ISBN,string Title,string Author);
       Book BookDetails(int BookId);
       User GetUserById(int userId);

    }
}
