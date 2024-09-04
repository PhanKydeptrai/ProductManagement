using MediatR;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Feature.GetAllUser;

public record GetAllUserQuery() : IRequest<Result<List<User>>>;


