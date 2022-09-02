using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicPlayer.Backend.Infrastructure.Data;

namespace MusicPlayer.Backend.Infrastructure;

public static class StartupSetup
{
    public static void AddDbContext(this IServiceCollection services, string connectionString, string userId, string password)
    {
        var sqlConnBuilder = new SqlConnectionStringBuilder();
        sqlConnBuilder.ConnectionString = connectionString;
        sqlConnBuilder.UserID = userId;
        sqlConnBuilder.Password = password;
        services.AddDbContext<MusicPlayerContext>(options =>
            options.UseSqlServer(sqlConnBuilder.ConnectionString, b => b.MigrationsAssembly("MusicPlayer.Backend.Infrastructure")));
    }
}
