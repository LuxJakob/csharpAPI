using FrogWorld.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrogWorld.ModelTests;

[TestClass]
public class FrogModelTests
{
    [TestMethod]
    public void TestModel()
    {
        // Arrange
        var frog = new Frog
        {
            Id = 1,
            Name = "MuscleFrog",
            ScreamingCroak = true
        };

        // Act
        int id = frog.Id;
        string name = frog.Name;
        bool screamingCroak = frog.ScreamingCroak;

        // Assert
        Assert.AreEqual(1, id);
        Assert.AreEqual("MuscleFrog", name);
        Assert.IsTrue(screamingCroak);
    }
}