using Microsoft.AspNetCore.Mvc;
using Sawari.DataAccess.Data;
using Sawari.Models;
using Sawari.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Sawari.Utility;

namespace SawariWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _UnitOFWork;
        public CategoryController(IUnitOfWork db)
        {
            _UnitOFWork = db;
        }


        public IActionResult Index()
        {
            List<Category> obj = _UnitOFWork.Category.GetAll().ToList();
            return View(obj);
        }

        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOFWork.Category.Add(obj);
                _UnitOFWork.Save();
                TempData["success"] = "Category Created Successfully";
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

            var category = _UnitOFWork.Category.Get(u => u.Id == id);

            if (category == null)
            {
                NotFound();
            }
            return View(category);






        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOFWork.Category.Update(obj);
                _UnitOFWork.Save();
                TempData["success"] = "Category Updated Successfully";

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

            var category = _UnitOFWork.Category.Get(u => u.Id == id);

            if (category == null)
            {
                NotFound();
            }
            return View(category);






        }
        [HttpPost]
        public IActionResult Delete(Category obj)
        {



            _UnitOFWork.Category.Remove(obj);
            _UnitOFWork.Save();
            TempData["success"] = "Category deleted Successfully";

            return RedirectToAction("Index");



        }
    }
}
