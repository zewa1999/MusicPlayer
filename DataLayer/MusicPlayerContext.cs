using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer;

public class MusicPlayerContext : DbContext
{

    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Song> Songs { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
           .UseLazyLoadingProxies()
           .UseSqlite("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=LibraryDatabase"/*connString*/);
    }
}
