using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPlayer.Backend.Infrastructure;

namespace MusicPlayer.Backend.UnitTests.InfrastructureTests;

[TestClass]
public class EntitiesHelperTests
{
    private EntitiesHelper _entitiesManager;

    [TestInitialize]
    public void Initialize()
    {
        _entitiesManager = new();
    }

    [TestMethod]
    public void HashPasswordShouldReturnDifferentHashesWhenPasswordAreDifferent()
    {
        var pass1 = "FirstPassword";
        var pass2 = "SecondPassword";

        var pass1Hash = _entitiesManager.HashPassword(pass1);
        var pass2Hash = _entitiesManager.HashPassword(pass2);

        Assert.AreNotEqual(pass1Hash, pass2Hash);
    }

    [TestMethod]
    public void HashPasswordShouldReturnEqualHashesWhenPasswordAreTheSame()
    {
        var pass1 = "MyPassword";
        var pass2 = "MyPassword";

        var pass1Hash = _entitiesManager.HashPassword(pass1);
        var pass2Hash = _entitiesManager.HashPassword(pass2);

        Assert.AreEqual(pass1Hash, pass2Hash);
    }

    [TestMethod]
    public void GetFileAsBytesResultShouldBeEqualWhenParsingTheSameFile()
    {
        var directoryPath = Directory.GetCurrentDirectory();
        var path1 = directoryPath + @"\InfrastructureTests\TestData\TextTest1.txt";

        var firstByteArray = _entitiesManager.GetFileAsBytes(path1);
        var secondByteArray = _entitiesManager.GetFileAsBytes(path1);

        Assert.IsTrue(firstByteArray.SequenceEqual(secondByteArray));
    }

    [TestMethod]
    public void GetFileAsBytesResultShouldNotBeEqualWhenParsingTheSameFile()
    {
        var directoryPath = Directory.GetCurrentDirectory();
        var path1 = directoryPath + @"\InfrastructureTests\TestData\TextTest1.txt";
        var path2 = directoryPath + @"\InfrastructureTests\TestData\TextTest2.txt";

        var firstByteArray = _entitiesManager.GetFileAsBytes(path1);
        var secondByteArray = _entitiesManager.GetFileAsBytes(path2);

        Assert.IsFalse(firstByteArray.SequenceEqual(secondByteArray));
    }

    [TestMethod]
    public void GetFileAsBytesShouldThrowArgumentNullExceptionWhenPathIsNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => _entitiesManager.GetFileAsBytes(null));
    }

    [TestMethod]
    public void GetFileAsBytesShouldThrowDirectoryNotFoundExceptionWhenPathIsNotFound()
    {
        var path1 = "NotExistentPath";

        Assert.ThrowsException<DirectoryNotFoundException>(() => _entitiesManager.GetFileAsBytes(path1));
    }
}