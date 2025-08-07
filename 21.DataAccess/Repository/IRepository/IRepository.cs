using System.Linq.Expressions;

namespace _21.DataAccess.Repository.IRepository;

public interface IRepository<T> where T: class
{
    IEnumerable<T> GetAll();
    T Get(Expression<Func<T, bool>> filter);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}