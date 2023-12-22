using FrogWorld.Models;
using FrogWorld.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrogWorld.ServiceTests;

[TestClass]
public class FrogServiceTests
{
    private readonly int existingFrogId = 1;
    private readonly int nonExistingFrogID = 42;

    [TestMethod]
    public void Get_All()
    {
        // Arrange
        List<Frog> expectedFrogList = new List<Frog>
        {
            new() { Id = 1, Name = "Big Frog", ScreamingCroak = true },
            new() { Id = 2, Name = "Fire Frog", ScreamingCroak = false }
        };

        // Act
        List<Frog> frogList = FrogService.GetAll();

        // Assert
        CollectionAssert.AreEqual(expectedFrogList, frogList);
    }

    [TestMethod]
    public void Get_ById()
    {
        // Arrange
        Frog expectedFrog = new Frog
        {
            Id = 1,
            Name = "Big Frog",
            ScreamingCroak = true
        };

        // Act
        Frog? foundFrog = FrogService.Get(existingFrogId);
        Frog? thatsNoFrog = FrogService.Get(nonExistingFrogID);

        // Assert
        Assert.AreEqual(expectedFrog, foundFrog);
        Assert.IsNull(thatsNoFrog);
    }

    [TestMethod]
    public void Post()
    {
        // Arrange
        Frog newFrogOne = new Frog
        {
            Id = existingFrogId,
            Name = "Mom Frog",
            ScreamingCroak = false
        };
        Frog newFrogTwo = new Frog
        {
            Id = nonExistingFrogID,
            Name = "Muscle Frog",
            ScreamingCroak = true
        };

        // Act
        FrogService.Add(newFrogOne);
        FrogService.Add(newFrogTwo);


        // Assert
        Frog? foundFrogOne = FrogService.Get(3);
        Frog? foundFrogTwo = FrogService.Get(4);
        Assert.AreEqual(newFrogOne, foundFrogOne);
        Assert.AreEqual(newFrogTwo, foundFrogTwo);
    }

    [TestMethod]
    public void Update()
    {
        // Arrange
        Frog updatedFrog = new Frog
        {
            Id = existingFrogId,
            Name = "Wednesday Frog",
            ScreamingCroak = false
        };

        // Act
        FrogService.Update(updatedFrog);
        Frog? foundFrog = FrogService.Get(existingFrogId);


        // Assert
        Assert.AreEqual(updatedFrog, foundFrog);
    }

    [TestMethod]
    public void Delete()
    {
        // Arrange
        int frogToDelete = 4;

        // Act
        FrogService.Delete(frogToDelete);
        Frog? foundFrog = FrogService.Get(frogToDelete);

        // Assert
        Assert.IsNull(foundFrog);
    }
}