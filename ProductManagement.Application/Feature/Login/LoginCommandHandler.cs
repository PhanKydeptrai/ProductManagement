using MediatR;
using NETCore.Encrypt;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.IRepositories;

namespace ProductManagement.Application.Feature.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<string>>
{
    private readonly IUserRepository _userRepository;
    public LoginCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        Result<string> result = new Result<string>
        {
            IsSuccess = false,
            Value = "",
            Errors = new List<string>()
        };
        
        if(_userRepository.IsEmailExist(request.Email) && await _userRepository.CheckPasswordAsync(EncryptProvider.Sha256(request.Password)))
        {
            result.IsSuccess = true;
            //return token
            result.Value = "Day la token";
        }
        return result;

    }
}
