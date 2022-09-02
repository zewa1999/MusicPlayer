using FluentValidation;
using MusicPlayer.Backend.Core.ProjectAggregate;

namespace MusicPlayer.Backend.Core.Validators;

public class ArtistValidator : AbstractValidator<Artist>
{
    public ArtistValidator()
    {
        this.RuleFor(a => a.Name)
             .NotNull().WithMessage("Null {PropertyName}")
             .NotEmpty().WithMessage("{PropertyName} is Empty")
             .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
             .Must(this.BeAValidName).WithMessage("{PropertyName} contains invalid characters");
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