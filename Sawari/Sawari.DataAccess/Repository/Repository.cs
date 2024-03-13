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
    internal class Repository<T> : IRepo<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;  

        public Repository(ApplicationDbContext db)
        {
            _db = db;

        }

        public T Add(T entity)
        {
            _db.dbse

           
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public T RemoveRange(List<T> Entities)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
