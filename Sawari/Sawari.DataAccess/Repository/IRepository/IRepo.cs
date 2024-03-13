using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sawari.DataAccess.Repository.IRepository
{
    public interface IRepo<T> where T : class
    {
        //T-Category
        List<T> GetAll();

        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);   

        void Remove(T entity);

        void RemoveRange(List<T> Entities);




    }
  
}
