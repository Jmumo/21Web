using _21.DataAccess.Data;
using _21.DataAccess.Repository.IRepository;

namespace _21.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext _db;
    public IRepositoryCategory IRepositoryCategory { get; private set; }
    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        IRepositoryCategory = new CategoryRepository(_db);
    }
    
    public void Save()
    {
        _db.SaveChanges();
    }
}