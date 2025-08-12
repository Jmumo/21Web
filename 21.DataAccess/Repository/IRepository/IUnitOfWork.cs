namespace _21.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    
    IRepositoryCategory IRepositoryCategory { get; }
    IRepositoryProduct IRepositoryProduct { get; }
    void Save();
    
}