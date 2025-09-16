using System.Diagnostics;
using _21.DataAccess.Repository;
using _21.DataAccess.Repository.IRepository;
using _21.Models.Models;
using _21Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace _21Web.Controllers
{    
    
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _context;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.IRepositoryProduct.GetAll(includeProperties:"Category");
            return View(products);
        }

        public IActionResult Details(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }
            Product product = _context.IRepositoryProduct.Get(u => u.Id == productId,includeProperties:"Category");
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
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
