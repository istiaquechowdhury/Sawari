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
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ProductController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _UnitOFWork = db;
            _WebHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            List<Product> obj = _UnitOFWork.Product.GetAll(includeproperties: "Category").ToList();
            return View(obj);
        }

        public IActionResult Upsert(int? id)
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


            if (id == null || id == 0)
            {
                //Create
                return View(productVM);
            }
            else
            {
                //Update
                productVM.Product = _UnitOFWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }






        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _WebHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productpath = Path.Combine(wwwRootPath, @"Images\Product");

                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var filestream = new FileStream(Path.Combine(productpath, fileName), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    productVM.Product.ImageUrl = @"\Images\Product\" + fileName;
                }

                if (productVM.Product.Id == 0)
                {
                    _UnitOFWork.Product.Add(productVM.Product);

                }
                else
                {
                    _UnitOFWork.Product.Update(productVM.Product);
                }
                if (productVM.Product.Id == 0)
                {
                    TempData["success"] = "Product Created Successfully";
                }
                else
                {
                    TempData["success"] = "Product Updated Successfully";
                }

                _UnitOFWork.Save();

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





        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> obj = _UnitOFWork.Product.GetAll(includeproperties: "Category").ToList();
            return Json(new { data = obj });
        }

        [HttpDelete] 
        public IActionResult Delete(int? id)
        {
            var ProdeucttobeDeleted = _UnitOFWork.Product.Get(u => u.Id == id);
            if (ProdeucttobeDeleted == null)
            {
                return Json(new { success = false, message = "Error while fetching" });
            }

            var oldImagePath = Path.Combine(_WebHostEnvironment.WebRootPath, ProdeucttobeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _UnitOFWork.Product.Remove(ProdeucttobeDeleted);
            _UnitOFWork.Save();

            return Json(new { success = true, message = "Successfully deleted" });


            #endregion
        }
    }
}
