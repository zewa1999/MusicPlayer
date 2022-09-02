using FluentValidation;
using MusicPlayer.Backend.Core.ProjectAggregate;
using System.Text.RegularExpressions;

namespace MusicPlayer.Backend.Core.Validators;

public class AccountValidator : AbstractValidator<Account>
{
    public AccountValidator()
    {
        RuleFor(a => a.Email)
            .EmailAddress().WithMessage("{PropertyName} invalid")
            .Length(5, 25).WithMessage("{PropertyName} must have atleast 5 characters")
            .NotEmpty().WithMessage("{PropertyName} must not be empty.")
            .NotNull().WithMessage("{PropertyName} must not be null.");

        RuleFor(a => a.Password)
            .Must(MustContainSymbolsAndUpperLetter).WithMessage("{PropertyName} must contain uppercase letters, lowercase letters and symbols.")
            .NotEmpty().WithMessage("{PropertyName} must not be empty.")
            .NotNull().WithMessage("{PropertyName} must not be null.");

        RuleFor(a => a.Username)
            .Length(5, 25).WithMessage("{PropertyName} must have atleast 5 characters")
            .NotEmpty().WithMessage("{PropertyName} must not be empty.");
    }

    private bool MustContainSymbolsAndUpperLetter(string password)
    {
        var expectedPasswordPattern = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");

        return expectedPasswordPattern.IsMatch(password);
    }
}