using Microsoft.EntityFrameworkCore;
using MusicPlayer.Backend.Core.ProjectAggregate;
using System.Reflection;

namespace MusicPlayer.Backend.Infrastructure.Data;

public class MusicPlayerContext : DbContext
{
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Song> Songs => Set<Song>();
    public DbSet<Artist> Artists => Set<Artist>();

    public MusicPlayerContext(DbContextOptions<MusicPlayerContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}