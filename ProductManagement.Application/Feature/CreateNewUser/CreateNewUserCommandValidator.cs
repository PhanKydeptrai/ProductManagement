using FluentValidation;
using ProductManagement.Domain.IRepositories;

namespace ProductManagement.Application.Feature.CreateNewUser;

public class CreateNewUserCommandValidator : AbstractValidator<CreateNewUserCommand>
{
    public CreateNewUserCommandValidator(IUserRepository userRepository)
    {
    
        RuleFor(a => a.UserName)
            .NotEmpty()
            .WithMessage("UserName is required");

        RuleFor(a => a.UserMail)
            .NotEmpty()
            .WithMessage("UserMail is required")
            .EmailAddress()
            .WithMessage("UserMail is not a valid email address")
            .Must(a => userRepository.IsEmailExist(a) == false)
            .WithMessage("UserMail is already exist");

        RuleFor(a => a.Role)
            .NotEmpty()
            .WithMessage("Role is required")
            .Must(a => a == "Admin" || a == "User").WithMessage("Role must be Admin or User");
    }
}
