using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MusicPlayer.Backend.Core.ProjectAggregate;
using MusicPlayer.Backend.Core.Services;
using MusicPlayer.Backend.Core.Validators;

namespace MusicPlayer.Backend.UnitTests.CoreTests.Services;

[TestClass]
public class AccountServiceTests : TestDbSetup<Account>
{
    private Account _account;
    private AccountService _service;
    private Mock<AccountValidator> _mockedValidator;

    [TestInitialize]
    public void Initialize()
    {
        _mockedValidator = new Mock<AccountValidator>();
        _service = new(repository, _mockedValidator.Object, _mockedLogger.Object);
    }
}