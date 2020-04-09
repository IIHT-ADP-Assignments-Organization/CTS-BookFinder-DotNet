using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookFinder.Entities;
using FluentNHibernate.Mapping;


namespace BookFinder.DataLayer.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.UserId);
            Map(x => x.UserName);
            Map(x => x.Email);
            Map(x => x.Password);
           
            Table("User");

        }
    }


}
