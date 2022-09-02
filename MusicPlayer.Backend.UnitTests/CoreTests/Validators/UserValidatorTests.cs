using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPlayer.Backend.Core.ProjectAggregate;
using MusicPlayer.Backend.Core.Validators;

namespace MusicPlayer.Backend.UnitTests.CoreTests.Validators;

[TestClass]
public class UserValidatorTests
{
    private UserValidator _validator;

    [TestInitialize]
    public void Initialize()
    {
        _validator = new();
    }

    [DataTestMethod]
    [DataRow("")]
    [DataRow(null)]
    [DataRow("a")]
    public void ValidatorShouldHaveErrorWhenFirstNameAndLastNameIsNotValid(string name)
    {
        var user = new User()
        {
            FirstName = name,
            LastName = name,
            Songs = new List<Song>()
            {
                new Song()
                {
                     Name = name,
                     Duration = "03:59",
                     Image = new byte[] { 0, 1, 2 },
                     Content = new byte[] { 0, 1, 2 },
                     Artists = new List<Artist>
                     { new Artist
                     {
                         Name = "Bon Jovi"
                     }
                     }
                }
            },
            Account = new Account()
            {
                Email = "email@email.com",
                Password = "Parola123@",
                Username = "cont123"
            }
        };

        Assert.IsFalse(_validator.Validate(user).IsValid);
    }

    [TestMethod]
    public void ValidatorShouldNotHaveErrorWhenFirstNameAndLastNameIsValid()
    {
        var user = new User()
        {
            FirstName = "Costache",
            LastName = "Andrei",
            Songs = new List<Song>()
            {
                new Song()
                {
                     Name = "O melodie",
                     Duration = "03:59",
                     Image = new byte[] { 0, 1, 2 },
                     Content = new byte[] { 0, 1, 2 },
                     Artists = new List<Artist>
                     { new Artist
                     {
                         Name = "Bon Jovi"
                     }
                     }
                }
            },
            Account = new Account()
            {
                Email = "email@email.com",
                Password = "Parola123@",
                Username = "cont123"
            }
        };

        var results = _validator.Validate(user);
        Assert.IsTrue(_validator.Validate(user).IsValid);
    }
}