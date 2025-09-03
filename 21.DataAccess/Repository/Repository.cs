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
    
    public IEnumerable<T> GetAll(String?  includeProperties = null)
    {
        IQueryable<T> query = dbSet;

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var var  in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
               query = query.Include(var); 
            }
        }
        return query.ToList();
    }

    public T Get(Expression<Func<T, bool>> filter,String? includeProperties = null)
    {
        
       
        IQueryable<T> query = dbSet;
        query = query.Where(filter);
        
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var var  in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(var); 
            }
        }
        
        return query.FirstOrDefault();
    }

    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);
      
    }

}
