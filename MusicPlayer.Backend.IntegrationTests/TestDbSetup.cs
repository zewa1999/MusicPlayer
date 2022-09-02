using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MusicPlayer.Backend.Infrastructure.Data;
using MusicPlayer.Backend.Infrastructure.Data.Repository;
using MusicPlayer.Backend.SharedKernel;
using MusicPlayer.Backend.SharedKernel.Interfaces;

namespace MusicPlayer.Backend.UnitTests.CoreTests;

public abstract class TestDbSetup<T>
    where T : BaseEntity
{
    private DbContextOptions<MusicPlayerContext> dbContextOptions = new DbContextOptionsBuilder<MusicPlayerContext>()
        .UseInMemoryDatabase(databaseName: "MusicPlayerDbTest")
        .Options;

    private MusicPlayerContext dbContext;

    protected Mock<ILogger> _mockedLogger;

    protected IBaseRepository<T> repository;

    //[AssemblyInitialize]
    public void InitializeDb()
    {
        dbContext = new(dbContextOptions);
        _mockedLogger = new();
        repository = new EfRepository<T>(dbContext, _mockedLogger.Object);
    }
}