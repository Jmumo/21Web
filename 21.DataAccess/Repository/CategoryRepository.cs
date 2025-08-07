using _21.DataAccess.Data;
using _21.DataAccess.Repository.IRepository;
using _21.Models.Models;

namespace _21.DataAccess.Repository;

public class CategoryRepository : Repository<Category> , IRepositoryCategory
{
    private ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Save()
    {
        _db.SaveChanges();
    }

    public void Update(Category obj)
    {
        _db.Categories.Update(obj);
    }
}