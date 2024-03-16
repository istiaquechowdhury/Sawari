using Sawari.DataAccess.Data;
using Sawari.DataAccess.Repository.IRepository;
using Sawari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sawari.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepositorycs
    {

        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);    
        }
    }
}
