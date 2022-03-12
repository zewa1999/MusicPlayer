using Microsoft.EntityFrameworkCore;
using MusicPlayer.API.Data;
using MusicPlayer.API.Data.Repository.Concretes;
using MusicPlayer.API.Data.Repository.Interfaces;
using MusicPlayer.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MusicPlayerContext>(options => options.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<ILogger>(svc => svc.GetRequiredService<ILogger<SongRepository>>());
builder.Services.AddTransient(typeof(ISongRepository), typeof(SongRepository));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();