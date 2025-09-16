using _21.DataAccess.Data;
using _21.DataAccess.Repository.IRepository;
using _21.Models.Models;
using _21.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _21Web.Controllers;

[Area("admin")]
[Authorize(Roles = SD.Role_Admin)]
public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private readonly IUnitOfWork _context;
    public CategoryController(IUnitOfWork context, ILogger<CategoryController> logger)
    {
       
       _context = context;
       _logger = logger; 
    }
    public IActionResult Index()
    {
        
        List<Category>  categories = _context.IRepositoryCategory.GetAll().ToList();
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
            _context.IRepositoryCategory.Add(category);
            _context.Save();
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
        Category category = _context.IRepositoryCategory.Get(u => u.Id == id);
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
            _context.IRepositoryCategory.Update(category);
            _context.Save();
            TempData["Message"] = "Category Updated Successfully";
            return RedirectToAction("Index", "Category");
        }
        return  View();
    }

    [HttpPost]
    public IActionResult DeleteCategory(int? id )
    {
        
        Category category = _context.IRepositoryCategory.Get(u => u.Id == id);
        _context.IRepositoryCategory.Remove(category);
        _context.Save();
        TempData["Message"] = "Category Deleted Successfully";
        return RedirectToAction("Index", "Category");
    }
}

//dotnet ef database update  