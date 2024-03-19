using Microsoft.AspNetCore.Mvc;
using Sawari.DataAccess.Data;
using Sawari.Models;
using Sawari.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SawariWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _UnitOFWork;
        public ProductController(IUnitOfWork db)
        {
            _UnitOFWork = db;
        }


        public IActionResult Index()
        {
            List<Product> obj = _UnitOFWork.Product.GetAll().ToList();
            return View(obj);
        }

        public IActionResult Create()
        {
            List<SelectListItem> Category = _UnitOFWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            })
            .ToList();

            ProductVM productVM = new()
            {
                CategoryList = Category,
                Product = new Product()

            };

            



            return View(productVM);

        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                _UnitOFWork.Product.Add(productVM.Product);
                _UnitOFWork.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            else
            {

                List<SelectListItem> Category = _UnitOFWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
                .ToList();

               
                productVM.CategoryList = Category;


                return View(productVM);



            }
           

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product = _UnitOFWork.Product.Get(u => u.Id == id);

            if (product == null)
            {
                NotFound();
            }
            return View(product);






        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOFWork.Product.Update(obj);
                _UnitOFWork.Save();
                TempData["success"] = "Product Updated Successfully";

                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product = _UnitOFWork.Product.Get(u => u.Id == id);

            if (product == null)
            {
                NotFound();
            }
            return View(product);






        }
        [HttpPost]
        public IActionResult Delete(Product obj)
        {



            _UnitOFWork.Product.Remove(obj);
            _UnitOFWork.Save();
            TempData["success"] = "Product deleted Successfully";

            return RedirectToAction("Index");



        }
    }
}
