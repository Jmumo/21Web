using _21.DataAccess.Repository.IRepository;
using _21.Models.Models;
using _21.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _21Web.Controllers;

[Area("admin")]
public class ProductController : Controller
{ 
    private readonly ILogger<ProductController> _logger;
    private readonly IUnitOfWork _context;
    
    private readonly IWebHostEnvironment _env;
    public ProductController(IUnitOfWork context, ILogger<ProductController> logger,IWebHostEnvironment env)
    {
       
       _context = context;
       _logger = logger;
       _env = env;
    }
    public IActionResult Index()
    {
        
        List<Product>  products = _context.IRepositoryProduct.GetAll(includeProperties:"Category").ToList();
        return View(products);
    }

    public IActionResult Upsert(int? id)
    {
        
        IEnumerable<SelectListItem> categories = _context.IRepositoryCategory.GetAll().Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });
        
        ViewBag.Categories = categories;
        
        ProductVM product = new ProductVM()
        {
            Product = new Product(),
            Categories = categories.ToList()
        };


        if (id != null)
        {
            product.Product = _context.IRepositoryProduct.Get(u => u.Id == id);
        }
        _logger.LogInformation("Product Url : {0}", product.Product.ImageUrl);
        return View(product);
    }
    
    
    
    [HttpPost]
    public IActionResult Upsert(ProductVM productVm,IFormFile? file )
    {
        String wwwrootPath = _env.WebRootPath;
        if (ModelState.IsValid)
        {
            
            if (file != null)
            {
                
                String fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                if (productVm.Product.ImageUrl != null)
                {
                    var oldImagePath = Path.Combine(wwwrootPath, productVm.Product.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                String productPath = Path.Combine(wwwrootPath, @"images/product");
                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                productVm.Product.ImageUrl = @"images/product/" + fileName;
            }
            
            
            if (productVm.Product.Id == 0)
            {
                _context.IRepositoryProduct.Add(productVm.Product);
                _context.Save();
                TempData["Message"] = "Product Added Successfully";
                return RedirectToAction("Index", "Product");
            }  
                      
            _context.IRepositoryProduct.Update(productVm.Product);
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

    #region API CALLs
    [HttpGet]
    public IActionResult GetAll()
    {
        List<Product> products = _context.IRepositoryProduct.GetAll(includeProperties:"Category").ToList();
        return Json(new { data = products });
    }
    #endregion
   
}