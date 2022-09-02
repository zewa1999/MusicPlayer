using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPlayer.Backend.Core.ProjectAggregate;
using MusicPlayer.Backend.Core.Validators;

namespace MusicPlayer.Backend.UnitTests.CoreTests.Validators;

[TestClass]
public class SongValidatorTests
{
    private SongValidator _validator;

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
        var song = new Song()
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
        };

        Assert.IsFalse(_validator.Validate(song).IsValid);
    }

    [TestMethod]
    public void ValidatorShouldNotHaveErrorWhenNameIsValid()
    {
        var artist = new Song()
        {
            Name = "It's My Life",
            Duration = "03:59",
            Image = new byte[] { 0, 1, 2 },
            Content = new byte[] { 0, 1, 2 },
            Artists = new List<Artist>
            { new Artist
            {
                Name = "Bon Jovi"
            }
            }
        };

        var results = _validator.Validate(artist);

        Assert.IsTrue(_validator.Validate(artist).IsValid);
    }

    [DataTestMethod]
    [DataRow("")]
    [DataRow(null)]
    [DataRow("a")]
    [DataRow("08 92")]
    public void ValidatorShouldHaveErrorWhenDurationIsNotValid(string duration)
    {
        var song = new Song()
        {
            Name = "O melodie",
            Duration = duration,
            Image = new byte[] { 0, 1, 2 },
            Content = new byte[] { 0, 1, 2 },
            Artists = new List<Artist>
            { new Artist
            {
                Name = "Bon Jovi"
            }
            }
        };

        Assert.IsFalse(_validator.Validate(song).IsValid);
    }

    [TestMethod]
    public void ValidatorShouldNotHaveErrorWhenDurationIsValid()
    {
        var artist = new Song()
        {
            Name = "It's My Life",
            Duration = "03:59",
            Image = new byte[] { 0, 1, 2 },
            Content = new byte[] { 0, 1, 2 },
            Artists = new List<Artist>
            { new Artist
            {
                Name = "Bon Jovi"
            }
            }
        };

        var results = _validator.Validate(artist);

        Assert.IsTrue(_validator.Validate(artist).IsValid);
    }

    [DataTestMethod]
    [DataRow(new byte[] { })]
    [DataRow(null)]
    public void ValidatorShouldHaveErrorWhenImageAndContentIsInvalid(byte[] image)
    {
        var artist = new Song()
        {
            Name = "It's My Life",
            Duration = "03:59",
            Image = image,
            Content = image,
            Artists = new List<Artist>
            { new Artist
            {
                Name = "Bon Jovi"
            }
            }
        };

        Assert.IsFalse(_validator.Validate(artist).IsValid);
    }

    [TestMethod]
    public void ValidatorShouldNotHaveErrorWhenImageAndContentIsValid()
    {
        var artist = new Song()
        {
            Name = "It's My Life",
            Duration = "03:59",
            Image = new byte[] { 0, 1, 2 },
            Content = new byte[] { 0, 1, 2 },
            Artists = new List<Artist>
            { new Artist
            {
                Name = "Bon Jovi"
            }
            }
        };

        var results = _validator.Validate(artist);

        Assert.IsTrue(_validator.Validate(artist).IsValid);
    }
}