using ProductManagement.Domain.Entities;

namespace ProductManagement.Domain.IRepositories;

public interface IUserRepository
{
    Task AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(User user);
    Task<List<User>> GetAllUsers();
    Task<User?> GetUserById(Guid id);
    Task<User?> GetUserByEmail(string email);
    bool IsEmailExist(string email);
    Task<IQueryable<User>> GetQueryAbleOfUser();
    Task<User> UserAuthenticate(string email, string password);
}
