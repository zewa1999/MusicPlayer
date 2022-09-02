using FluentValidation;
using Microsoft.Extensions.Logging;
using MusicPlayer.Backend.Core.Interfaces;
using MusicPlayer.Backend.Core.ProjectAggregate;
using MusicPlayer.Backend.SharedKernel.Interfaces;

namespace MusicPlayer.Backend.Core.Services;

public class UserService : BaseService<User>, IUserService
{
    public UserService(IBaseRepository<User> repository, IValidator<User> validator, ILogger logger) : base(repository, validator, logger)
    {
    }
}