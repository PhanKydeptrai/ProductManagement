using System;
using FluentValidation;
using ProductManagement.Domain.IRepositories;

namespace ProductManagement.Application.Feature.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator(IUserRepository userRepository)
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid")
            .Must(a => userRepository.IsEmailExist(a) == false)
            .WithMessage("Email is already exist");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("UserName is required");
    }
}
