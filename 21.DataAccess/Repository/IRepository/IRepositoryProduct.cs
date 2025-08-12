using _21.Models.Models;

namespace _21.DataAccess.Repository.IRepository;

public interface IRepositoryProduct : IRepository<Product>
{
    void Update(Product obj);
}
