using MediatR;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Feature.GetUserByName;

public record GetUserByNameQuery : IRequest<Result<List<User>>>
{
    public string? UserName { get; set; }
}
