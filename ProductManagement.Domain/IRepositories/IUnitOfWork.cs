namespace ProductManagement.Domain.IRepositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
