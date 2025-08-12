using _21.DataAccess.Repository.IRepository;
using _21.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace _21Web.Controllers;

[Area("admin")]
public class ProductController : Controller
{ 
    private readonly ILogger<ProductController> _logger;
    private readonly IUnitOfWork _context;
    public ProductController(IUnitOfWork context, ILogger<ProductController> logger)
    {
       
       _context = context;
       _logger = logger; 
    }
    public IActionResult Index()
    {
        
        List<Product>  products = _context.IRepositoryProduct.GetAll().ToList();
        return View(products);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Product product)
    {

        if (ModelState.IsValid)
        {
            _context.IRepositoryProduct.Add(product);
            _context.Save();
            TempData["Message"] = "Product Added Successfully";
            return RedirectToAction("Index", "Product");
        }
        return  View();
    }
    
    public IActionResult Edit( int? id )
    {

        if (id == null || id == 0)
        {
            return NotFound(); 
        }
        Product product = _context.IRepositoryProduct.Get(u => u.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }
    
    [HttpPost]
    public IActionResult Edit (Product product)
    {

      
        if (ModelState.IsValid)
        {
            _context.IRepositoryProduct.Update(product);
            _context.Save();
            TempData["Message"] = "Product Updated Successfully";
            return RedirectToAction("Index", "Product");
        }
        return  View();
    }

    [HttpPost]
    public IActionResult DeleteProduct(int? id )
    {
        
        Product product = _context.IRepositoryProduct.Get(u => u.Id == id);
        _context.IRepositoryProduct.Remove(product);
        _context.Save();
        TempData["Message"] = "Product Deleted Successfully";
        return RedirectToAction("Index", "Product");
    }
}