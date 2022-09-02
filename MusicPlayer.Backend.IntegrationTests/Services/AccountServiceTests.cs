using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MusicPlayer.Backend.Core.ProjectAggregate;
using MusicPlayer.Backend.Core.Services;
using MusicPlayer.Backend.Core.Validators;

namespace MusicPlayer.Backend.UnitTests.CoreTests.Services;

[TestClass]
public class AccountServiceTests : TestDbSetup<Account>
{
    private AccountService _service;
    private AbstractValidator<Account> _validator;

    //[ClassInitialize]
    //public void InitializeDatabase()
    //{
    //}

    [TestInitialize]
    public void Initialize()
    {
        base.InitializeDb();
        _validator = new AccountValidator();
        _service = new(repository, _validator, _mockedLogger.Object);
    }

    [TestMethod]
    public void InsertShouldReturnTrueWhenModelIsValid()
    {
        var account = new Account()
        {
            Email = "email@email.com",
            Password = "Parola123@",
            Username = "cont123"
        };

        Assert.IsTrue(_service.Insert(account));
    }

    [TestMethod]
    public void InsertShouldReturnFalseWhenModelIsInvalid()
    {
        var account = new Account()
        {
            Email = "email@email.com"
        };

        Assert.IsFalse(_service.Insert(account));
    }
}