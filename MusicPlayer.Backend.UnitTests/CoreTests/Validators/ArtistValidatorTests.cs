using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPlayer.Backend.Core.ProjectAggregate;
using MusicPlayer.Backend.Core.Validators;

namespace MusicPlayer.Backend.UnitTests.CoreTests.Validators;

[TestClass]
public class ArtistValidatorTests
{
    private ArtistValidator _validator;

    [TestInitialize]
    public void Initialize()
    {
        _validator = new();
    }

    [DataTestMethod]
    [DataRow("")]
    [DataRow(null)]
    [DataRow("a")]
    public void ValidatorShouldHaveErrorWhenNameIsNotValid(string name)
    {
        var artist = new Artist()
        {
            Name = name
        };

        Assert.IsFalse(_validator.Validate(artist).IsValid);
    }

    [TestMethod]
    public void ValidatorShouldNotHaveErrorWhenNameIsValid()
    {
        var artist = new Artist()
        {
            Name = "Andrei Costache"
        };

        Assert.IsTrue(_validator.Validate(artist).IsValid);
    }
}