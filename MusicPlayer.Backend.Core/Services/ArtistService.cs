using FluentValidation;
using Microsoft.Extensions.Logging;
using MusicPlayer.Backend.Core.Interfaces;
using MusicPlayer.Backend.Core.ProjectAggregate;
using MusicPlayer.Backend.SharedKernel.Interfaces;

namespace MusicPlayer.Backend.Core.Services;

public class ArtistService : BaseService<Artist>, IArtistService
{
    public ArtistService(IBaseRepository<Artist> repository, IValidator<Artist> validator, ILogger logger) : base(repository, validator, logger)
    {
    }
}