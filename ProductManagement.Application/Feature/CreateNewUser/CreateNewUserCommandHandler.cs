using FluentValidation.Results;
using MediatR;
using NETCore.Encrypt;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.IRepositories;

namespace ProductManagement.Application.Feature.CreateNewUser;

public class CreateNewUserCommandHandler : IRequestHandler<CreateNewUserCommand, Result<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public CreateNewUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result<bool>> Handle(CreateNewUserCommand request, CancellationToken cancellationToken)
    {
        var result = new Result<bool>
        {
            Value = false,
            IsSuccess = false,
            Errors = new List<string>(),    
        };

        //Validate
        CreateNewUserCommandValidator validator = new CreateNewUserCommandValidator(_userRepository);
        ValidationResult validationResult = validator.Validate(request);
        if(!validationResult.IsValid)
        {
            foreach(var error in validationResult.Errors)
            {
                result.Errors.Add(error.ErrorMessage);
            }
            return result;
        }  

        //Create new user 
        var user = new User
        {
            UserId = Guid.NewGuid(),
            UserName = request.UserName,
            UserMail = request.UserMail,
            Password = EncryptProvider.Sha256("123"), //Default password
            Role = request.Role
        };

        await _userRepository.AddUser(user);
        await _unitOfWork.SaveChangesAsync();
        result.Value = true;
        result.IsSuccess = true;


        return result;
    }
}

    