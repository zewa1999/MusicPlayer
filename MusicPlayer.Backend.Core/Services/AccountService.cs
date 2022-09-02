using FluentValidation;
using Microsoft.Extensions.Logging;
using MusicPlayer.Backend.Core.Interfaces;
using MusicPlayer.Backend.Core.ProjectAggregate;
using MusicPlayer.Backend.SharedKernel.Interfaces;

namespace MusicPlayer.Backend.Core.Services;

public class AccountService : BaseService<Account>, IAccountService
{
    public AccountService(IBaseRepository<Account> repository, IValidator<Account> validator, ILogger logger)
        : base(repository, validator, logger)
    {
    }
}