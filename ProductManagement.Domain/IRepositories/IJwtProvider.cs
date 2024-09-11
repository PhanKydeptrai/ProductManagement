using ProductManagement.Domain.Entities;

namespace ProductManagement.Domain.IRepositories;

public interface IJwtProvider
{
    string GenerateJwtToken(User user);
}
