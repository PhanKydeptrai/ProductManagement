using MediatR;
using NETCore.Encrypt;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.IRepositories;

namespace ProductManagement.Application.Feature.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<string>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }
    
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        Result<string> result = new Result<string>
        {
            IsSuccess = false,
            Value = "",
            Errors = new List<string>()
        };
        

        //Get user
        var user = await _userRepository.UserAuthenticate(request.Email, EncryptProvider.Sha256(request.Password));

        if(user != null)
        {
            result.IsSuccess = true;
            //return token
            result.Value = _jwtProvider.GenerateJwtToken(user);
        }
        return result; 

    }
}
