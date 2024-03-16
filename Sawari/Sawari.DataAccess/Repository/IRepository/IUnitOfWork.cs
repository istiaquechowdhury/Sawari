﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawari.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepositorycs Category { get; }
        IProductRepository Product { get; } 
        void Save();
        
    }
}
