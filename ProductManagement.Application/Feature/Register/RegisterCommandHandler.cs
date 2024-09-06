using FluentValidation.Results;
using MediatR;
using NETCore.Encrypt;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.IRepositories;

namespace ProductManagement.Application.Feature.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }
    
    public async Task<Result<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        Result<bool> result = new Result<bool>
        {
            Value = false,
            IsSuccess = false,
            Errors = new List<string>()
        };
        //Validate
        RegisterCommandValidator validator = new RegisterCommandValidator(_userRepository);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                result.Errors.Add(error.ErrorMessage);
            }
            return result;
        }
        
        //Create new user
        var user = new User()
        {
            UserId = Guid.NewGuid(),
            UserName = request.UserName,
            UserMail = request.Email,
            Password = EncryptProvider.Sha256(request.Password),
            Role = "User"
        };
        await _userRepository.AddUser(user);
        await _unitOfWork.SaveChangesAsync();
        result.IsSuccess = result.Value = true;
        return result;
    }
}
