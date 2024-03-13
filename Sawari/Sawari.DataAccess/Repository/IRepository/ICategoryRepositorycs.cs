using Sawari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawari.DataAccess.Repository.IRepository
{
    public interface ICategoryRepositorycs : IRepo<Category>
    {
        void Update(Category obj);

        void Save();
    }
}
