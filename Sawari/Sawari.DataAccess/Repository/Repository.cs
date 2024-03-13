using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Sawari.DataAccess.Data;
using Sawari.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sawari.DataAccess.Repository
{
    public class Repository<T> : IRepo<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;  

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>();

        }

        public void Add(T entity)
        {
            dbset.Add(entity);  

           
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public List<T> GetAll()
        {
            IQueryable<T> list = dbset;

            return list.ToList();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);   
        }

        public void RemoveRange(List<T> Entities)
        {
            dbset.RemoveRange(Entities);
        }

      
    }
}
