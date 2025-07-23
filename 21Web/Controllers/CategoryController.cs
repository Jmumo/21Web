using _21Web.Data;
using _21Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace _21Web.Controllers;


public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ApplicationDbContext _context;
    public CategoryController(ApplicationDbContext context, ILogger<CategoryController> logger)
    {
       
       _context = context;
       _logger = logger; 
    }
    public IActionResult Index()
    {
        
        List<Category>  categories = _context.Categories.ToList();
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }
}