using System;
using FluentValidation;

namespace ProductManagement.Application.Feature.CreateNewUser;

public class CreateNewUserCommandValidator : AbstractValidator<CreateNewUserCommand>
{
    public CreateNewUserCommandValidator()
    {
        RuleFor(a => a.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(3).WithMessage("Password must be at least 3 characters");

        RuleFor(a => a.UserName)
            .NotEmpty()
            .WithMessage("UserName is required");

        RuleFor(a => a.UserMail)
            .NotEmpty()
            .WithMessage("UserMail is required")
            .EmailAddress()
            .WithMessage("UserMail is not a valid email address");

        RuleFor(a => a.Role)
            .NotEmpty()
            .WithMessage("Role is required")
            .Must(a => a == "Admin" || a == "User");
    }
}
