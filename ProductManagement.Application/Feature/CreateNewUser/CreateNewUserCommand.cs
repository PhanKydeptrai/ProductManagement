using MediatR;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Feature.CreateNewUser;

public class CreateNewUserCommand : IRequest<Result<bool>>

{
    public string UserName { get; set; }
    public string UserMail { get; set; }
    public string Role { get; set; }
}
