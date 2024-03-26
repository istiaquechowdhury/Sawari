using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Sawari.DataAccess.Repository.IRepository;
using Sawari.Models;
using System.Diagnostics;

namespace SawariWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
           List<Product> products = _unitOfWork.Product.GetAll(includeproperties:"Category").ToList();
           return View(products);
        }

        public IActionResult Details(int? id)
        {
            var Product = _unitOfWork.Product.Get(u=> u.Id==id,includeproperties: "Category");
            return View(Product);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}