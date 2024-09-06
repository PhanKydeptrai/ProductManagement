using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.IRepositories;

namespace ProductManagement.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ProductManagementDbContext _context;
    public UserRepository(ProductManagementDbContext context)
    {
        _context = context;
    }

    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public void DeleteUser(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users.SingleAsync(u => u.UserMail == email);
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public bool IsEmailExist(string email)
    {
        var check = _context.Users.Any(u => u.UserMail == email);
        return check;
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
    }
}
