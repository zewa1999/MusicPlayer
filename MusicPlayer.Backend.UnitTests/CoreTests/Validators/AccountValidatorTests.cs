using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPlayer.Backend.Core.ProjectAggregate;
using MusicPlayer.Backend.Core.Validators;

namespace MusicPlayer.Backend.UnitTests.CoreTests.Validators;

[TestClass]
public class AccountValidatorTests
{
    private AccountValidator _accountValidator;

    [TestInitialize]
    public void Initialize()
    {
        _accountValidator = new();
    }

    [DataTestMethod]
    [DataRow("")]
    [DataRow("emailinvalid")]
    [DataRow("<4ch")]
    [DataRow(null)]
    public void ValidatorShouldHaveErrorWhenEmailIsNotValid(string email)
    {
        var account = new Account()
        {
            Email = email
        };
        _accountValidator.Validate(account);

        Assert.IsFalse(_accountValidator.Validate(account).IsValid);
    }

    [TestMethod]
    public void ValidatorShouldNotHaveErrorWhenEmailIsValid()
    {
        var account = new Account()
        {
            Email = "email@email.com",
            Password = "Parola123@",
            Username = "cont123"
        };

        Assert.IsTrue(_accountValidator.Validate(account).IsValid);
    }

    [DataTestMethod]
    [DataRow("")]
    [DataRow("parola123")]
    [DataRow("<4ch")]
    [DataRow(null)]
    public void ValidatorShouldHaveErrorsWhenPasswordIsInvalid(string password)
    {
        var account = new Account()
        {
            Password = password
        };
        _accountValidator.Validate(account);

        Assert.IsFalse(_accountValidator.Validate(account).IsValid);
    }

    [TestMethod]
    public void ValidatorShouldNotHaveErrorWhenPasswordIsValid()
    {
        var account = new Account()
        {
            Email = "email@email.com",
            Password = "Parola123@",
            Username = "cont123"
        };
        _accountValidator.Validate(account);

        Assert.IsTrue(_accountValidator.Validate(account).IsValid);
    }
}