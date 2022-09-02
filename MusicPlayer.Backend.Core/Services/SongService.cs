using FluentValidation;
using Microsoft.Extensions.Logging;
using MusicPlayer.Backend.Core.Interfaces;
using MusicPlayer.Backend.Core.ProjectAggregate;
using MusicPlayer.Backend.SharedKernel.Interfaces;

namespace MusicPlayer.Backend.Core.Services;

public class SongService : BaseService<Song>, ISongService
{
    public SongService(IBaseRepository<Song> repository, IValidator<Song> validator, ILogger logger) : base(repository, validator, logger)
    {
    }
}