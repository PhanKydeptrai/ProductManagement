using MediatR;
using ProductManagement.Domain.Entities;
namespace ProductManagement.Application.Feature.Login;
public class LoginCommand : IRequest<Result<string>>
{
    public string Email { get; set; }
    public string Password { get; set; }    
}