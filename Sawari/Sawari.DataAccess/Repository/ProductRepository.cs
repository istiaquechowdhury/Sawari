using Sawari.DataAccess.Data;
using Sawari.DataAccess.Repository.IRepository;
using Sawari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawari.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var ProductObj = _db.Products.FirstOrDefault(u => u.Id == product.Id);  
            
            if (ProductObj != null)
            {
                ProductObj.Title = product.Title;   
                ProductObj.ISBN = product.ISBN;
                ProductObj.Description = product.Description;
                ProductObj.Price = product.Price;
                ProductObj.ListPrice = product.ListPrice;
                ProductObj.Price50 = product.Price50;
                ProductObj.Price100 = product.Price100;
                ProductObj.Author = product.Author; 
                ProductObj.CategoryId = product.CategoryId;

                if(product.ImageUrl != null)
                {
                    ProductObj.ImageUrl = product.ImageUrl;
                }


            }
        }
    }
}
