using ProductManagement.Domain.Entities;

namespace ProductManagement.Domain.IRepositories;

public interface IJwtProvider
{
    string Generrate(User user);
}
