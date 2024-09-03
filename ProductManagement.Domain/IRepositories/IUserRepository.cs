using ProductManagement.Domain.Entities;

namespace ProductManagement.Domain.IRepositories;

public interface IUserRepository
{
    Task AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(User user);
    Task<User?> GetUserById(Guid id);
    Task<User?> GetUserByEmail(string email);
    Task<bool> IsEmailExist(string email);

}
