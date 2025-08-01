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
    [HttpPost]
    public IActionResult Create(Category category)
    {

        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "Name cannot be the same as Display Order");
        }
        if (ModelState.IsValid)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            TempData["Message"] = "Category Added Successfully";
            return RedirectToAction("Index", "Category");
        }
        return  View();
    }
    
    public IActionResult Edit( int? id )
    {

        if (id == null || id == 0)
        {
            return NotFound(); 
        }
        Category category = _context.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }
    
    [HttpPost]
    public IActionResult Edit (Category category)
    {

        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "Name cannot be the same as Display Order");
        }
        if (ModelState.IsValid)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            TempData["Message"] = "Category Updated Successfully";
            return RedirectToAction("Index", "Category");
        }
        return  View();
    }

    [HttpPost]
    public IActionResult DeleteCategory(int? id )
    {
        
        Category category = _context.Categories.Find(id);
        _context.Categories.Remove(category);
        _context.SaveChanges();
        TempData["Message"] = "Category Deleted Successfully";
        return RedirectToAction("Index", "Category");
    }
}