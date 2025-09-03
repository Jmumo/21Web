using System.Linq.Expressions;

namespace _21.DataAccess.Repository.IRepository;

public interface IRepository<T> where T: class
{
    IEnumerable<T> GetAll(String? includeProperties = null);
    T Get(Expression<Func<T, bool>> filter,String? includeProperties = null);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}