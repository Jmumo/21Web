using System.Linq.Expressions;
using _21.DataAccess.Data;
using _21.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace _21.DataAccess.Repository;

public class Repository<T>  : IRepository<T> where T : class
{

    private readonly ApplicationDbContext _db;
    internal DbSet<T> dbSet;

    public Repository(ApplicationDbContext db)
    {
        _db = db;
        dbSet = db.Set<T>();
    }
    
    public IEnumerable<T> GetAll()
    {
        IQueryable<T> query = dbSet;
        return query.ToList();
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        
       
        IQueryable<T> query = dbSet;
        query = query.Where(filter);
        return query.FirstOrDefault();
    }

    public void Add(T Entity)
    {
        dbSet.Add(Entity);
    }

    public void Update(T Entity)
    {
        dbSet.Update(Entity);
    }

    public void Remove(T Entity)
    {
        dbSet.Remove(Entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);
    }
}
