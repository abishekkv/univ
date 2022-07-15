using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UmsWeb.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //define crud operation method
        //Get whole database
        IEnumerable<T> GetAll(string? includeProperties =null);
        //get first or default
        T GetFirstOrDefault(Expression<Func<T,bool>> filter, string? includeProperties = null);
        //Add 
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(T entity);



    }
}
