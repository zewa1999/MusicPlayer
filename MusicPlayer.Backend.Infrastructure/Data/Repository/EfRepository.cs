using Microsoft.Extensions.Logging;
using MusicPlayer.Backend.SharedKernel;
using MusicPlayer.Backend.SharedKernel.Interfaces;

namespace MusicPlayer.Backend.Infrastructure.Data.Repository;

public class EfRepository<T> : EfBaseRepository<T>, IBaseRepository<T>
    where T : BaseEntity
{
    public EfRepository(MusicPlayerContext ctx, ILogger logger) : base(ctx, logger)
    {
    }
}