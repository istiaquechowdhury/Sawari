using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SawariwebRazor.Data;
using SawariwebRazor.Models;

namespace SawariwebRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {

       
        private readonly ApplicationDbContext _db;

        public List<Category> Categories { get; set; }  

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;   
            
        }
        public void OnGet()
        {
            Categories = _db.Categories.ToList();
        }
    }
}
