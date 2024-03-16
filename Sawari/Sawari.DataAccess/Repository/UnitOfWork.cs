﻿using Sawari.DataAccess.Data;
using Sawari.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawari.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _db;

        public ICategoryRepositorycs Category { get; private set; }

        public IProductRepository Product { get; private set; } 

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }

       



        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
