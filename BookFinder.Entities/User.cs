using System;
using System.Collections.Generic;
using System.Text;

namespace BookFinder.Entities
{
   public class User
    {
       public virtual int UserId { get; set; }
       public virtual string UserName { get; set; }
       public virtual string Email { get; set; }
       public virtual string Password { get; set; }
    }
}
