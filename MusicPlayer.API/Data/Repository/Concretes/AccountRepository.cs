using MusicPlayer.API.Data.Repository.Interfaces;
using MusicPlayer.API.Models;

namespace MusicPlayer.API.Data.Repository.Concretes;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(MusicPlayerContext ctx, ILogger logger) : base(ctx, logger)
    {
    }
}