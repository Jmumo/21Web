using _21.DataAccess.Data;
using _21.Models.Models;

namespace _21.DataAccess.Repository.IRepository;

public class ProductRepository : Repository<Product> , IRepositoryProduct
{
    private ApplicationDbContext _db;

    public ProductRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }


    public void Update(Category obj)
    {
        _db.Categories.Update(obj);
    }
}