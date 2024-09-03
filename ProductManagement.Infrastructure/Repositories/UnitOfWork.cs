using ProductManagement.Domain.IRepositories;

namespace ProductManagement.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductManagementDbContext _context;
    public UnitOfWork(ProductManagementDbContext context)
    {
        _context = context;
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
