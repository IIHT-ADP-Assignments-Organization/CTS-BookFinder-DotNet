using BookFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookFinder.DataLayer.NHibernate
{
    public interface IMapperSession
    {
        void BeginTransaction();
        System.Threading.Tasks.Task Commit();
        System.Threading.Tasks.Task Rollback();
        void CloseTransaction();
        System.Threading.Tasks.Task Save(List<User> entity);
        System.Threading.Tasks.Task Delete(User entity);
        IQueryable<User> user { get; }
    }
}
