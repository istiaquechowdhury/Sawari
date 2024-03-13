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

        T Add(T entity);    

        T Update(T entity); 

        T Remove(T entity);

        T RemoveRange(List<T> Entities);




    }
  
}
