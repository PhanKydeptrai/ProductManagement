using MediatR;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Feature.Register;

public class RegisterCommand : IRequest<Result<bool>>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    
}
