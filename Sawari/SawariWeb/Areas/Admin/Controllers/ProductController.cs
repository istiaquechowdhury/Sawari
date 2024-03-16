using Microsoft.AspNetCore.Mvc;
using Sawari.DataAccess.Data;
using Sawari.Models;
using Sawari.DataAccess.Repository.IRepository;

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

            return View();

        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOFWork.Product.Add(obj);
                _UnitOFWork.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            return View();

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
