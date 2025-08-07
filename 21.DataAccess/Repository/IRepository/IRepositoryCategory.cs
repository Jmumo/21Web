using _21.Models.Models;

namespace _21.DataAccess.Repository.IRepository;

public interface IRepositoryCategory : IRepository<Category>
{
    void Update(Category obj);
  
}