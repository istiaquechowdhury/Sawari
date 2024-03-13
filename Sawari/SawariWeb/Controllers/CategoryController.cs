using Microsoft.AspNetCore.Mvc;
using Sawari.DataAccess.Data;
using Sawari.Models;
using Sawari.DataAccess.Repository.IRepository;

namespace SawariWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepositorycs _CategoryRepo;
        public CategoryController(ICategoryRepositorycs db)
        {
            _CategoryRepo = db;
        }


        public IActionResult Index()
        {
            List<Category> obj = _CategoryRepo.GetAll().ToList();
            return View(obj);
        }

        public IActionResult Create()
        {
           
            return View();
           
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            {
                _CategoryRepo.Add(obj);
                _CategoryRepo.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();  
            }

            var category = _CategoryRepo.Get(u => u.Id == id);

            if(category == null) 
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
                _CategoryRepo.Update(obj);
                _CategoryRepo.Save();
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

            var category = _CategoryRepo.Get(u => u.Id == id);

            if (category == null)
            {
                NotFound();
            }
            return View(category);






        }
        [HttpPost]
        public IActionResult Delete(Category obj)
        {



               _CategoryRepo.Remove(obj);
               _CategoryRepo.Save();
               TempData["success"] = "Category deleted Successfully";

                return RedirectToAction("Index");
            
            

        }
    }
}
