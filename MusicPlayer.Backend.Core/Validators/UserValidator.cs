using FluentValidation;
using MusicPlayer.Backend.Core.ProjectAggregate;

namespace MusicPlayer.Backend.Core.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.FirstName)
            .NotNull().WithMessage("Null {PropertyName}")
            .NotEmpty().WithMessage("{PropertyName} is Empty")
            .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
            .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

        RuleFor(u => u.LastName)
            .NotNull().WithMessage("Null {PropertyName}")
            .NotEmpty().WithMessage("{PropertyName} is Empty")
            .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
            .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

        RuleFor(u => u.Account).SetValidator(new AccountValidator());

        RuleForEach(u => u.Songs)
           .SetValidator(new SongValidator());
    }

    protected bool BeAValidName(string name)
    {
        if (name == null)
        {
            return false;
        }

        name = name.Replace(" ", string.Empty);
        name = name.Replace("-", string.Empty);
        return name.All(char.IsLetter);
    }
}