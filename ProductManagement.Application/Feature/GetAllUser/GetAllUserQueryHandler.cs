using MediatR;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.IRepositories;

namespace ProductManagement.Application.Feature.GetAllUser;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, Result<List<User>>>
{
    private readonly IUserRepository _userRepository;
    
    public GetAllUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Result<List<User>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        Result<List<User>> result = new Result<List<User>>{
            Value = new List<User>(),
            IsSuccess = false,
        };
        
        result.Value = await _userRepository.GetAllUsers();
        if(result.Value.Count > 0)
        {
            result.IsSuccess = true;
        }
        return result;
        
    }
}
