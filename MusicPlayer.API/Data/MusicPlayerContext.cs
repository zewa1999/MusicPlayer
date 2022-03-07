using Microsoft.EntityFrameworkCore;
using MusicPlayer.API.Models;
using System.Collections.Generic;

namespace MusicPlayer.API.Data;

public class MusicPlayerContext : DbContext
{
    public MusicPlayerContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Artist> Artists { get; set; }
}