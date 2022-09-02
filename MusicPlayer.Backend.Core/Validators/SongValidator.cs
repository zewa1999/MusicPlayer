using FluentValidation;
using MusicPlayer.Backend.Core.ProjectAggregate;

namespace MusicPlayer.Backend.Core.Validators;

public class SongValidator : AbstractValidator<Song>
{
    public SongValidator()
    {
        RuleFor(a => a.Name)
              .NotNull().WithMessage("Null {PropertyName}")
              .NotEmpty().WithMessage("{PropertyName} is Empty")
              .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid");
        RuleFor(a => a.Duration)
              .NotEmpty().WithMessage("{PropertyName} is Empty")
              .NotNull().WithMessage("Null {PropertyName}")
              .Must(MustBeAValidDuration).WithMessage("{PropertyName} is invalid");

        RuleFor(a => a.Image)
              .NotEmpty().WithMessage("{PropertyName} is Empty")
              .NotNull().WithMessage("Null {PropertyName}");

        RuleFor(a => a.Content)
              .NotEmpty().WithMessage("{PropertyName} is Empty")
              .NotNull().WithMessage("Null {PropertyName}");

        RuleForEach(a => a.Artists).SetValidator(new ArtistValidator());
    }

    protected bool MustBeAValidDuration(string duration) => duration.Contains(":") && duration.Replace(":", string.Empty).All(char.IsNumber);
}