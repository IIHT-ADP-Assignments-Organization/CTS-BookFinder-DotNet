using System;
using System.Collections.Generic;
using System.Text;

namespace BookFinder.Tests.Exceptions
{
   public class UserExistException :Exception
    {
        public string Messages;

        public UserExistException()
        {
            Messages = "Already have an Account please login";
        }
        public UserExistException(string message)
        {
            Messages = message;
        }
    }
}

