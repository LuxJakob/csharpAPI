using FrogWorld.Controllers;
using FrogWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrogWorld.ControllerTests;

[TestClass]
public class FrogControllerTests
{
    private readonly int existingFrogId = 1;
    private readonly int nonExistingFrogID = 42;

    [TestMethod]
    public void GetAll_AllFrogs()
    {
        // Arrange
        var controller = new FrogController();

        // Act
        var result = controller.GetAll() as ActionResult<List<Frog>>;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result.Value, typeof(List<Frog>));
    }

    [TestMethod]
    public void Get_FrogByIdSuccess()
    {
        // Arrange
        var controller = new FrogController();

        // Act
        var result = controller.Get(existingFrogId);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(ActionResult<Frog>));
    }

    [TestMethod]
    public void Get_FrogByIdNotFound()
    {
        // Arrange
        var controller = new FrogController();

        // Act
        var result = controller.Get(nonExistingFrogID);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
    }

    [TestMethod]
    public void Create_CreatedAtActionResult()
    {
        // Arrange
        var controller = new FrogController();
        var newFrog = new Frog() { Id = 9, Name = "Quappi", ScreamingCroak = false };

        // Act
        var result = controller.Create(newFrog);
        var resultAction = (CreatedAtActionResult)result;
        Frog? newFoggo = (Frog?)resultAction.Value;

        // Assert
        Assert.IsNotNull(newFoggo);
        Assert.AreEqual(nameof(controller.Get), resultAction.ActionName);
        Assert.AreEqual(newFrog.Name, newFoggo?.Name);
    }

    [TestMethod]
    public void Update_NoContentSuccess()
    {
        // Arrange
        var controller = new FrogController();
        var updatedFrog = new Frog()
        {
            Id = existingFrogId,
            Name = "Fire Frog",
            ScreamingCroak = true
        };

        // Act
        var result = controller.Update(existingFrogId, updatedFrog);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(NoContentResult));
    }

    [TestMethod]
    public void Update_BadRequest()
    {
        // Arrange
        var controller = new FrogController();
        var updatedFrog = new Frog()
        {
            Id = nonExistingFrogID,
            Name = "Fire Frog",
            ScreamingCroak = true
        };

        // Act
        var result = controller.Update(nonExistingFrogID, updatedFrog);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }

    [TestMethod]
    public void Delete_NoContentSuccess()
    {
        // Arrange
        var controller = new FrogController();

        // Act
        var result = controller.Delete(existingFrogId) as IActionResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(NoContentResult));
    }

    [TestMethod]
    public void Delete_NotFound()
    {
        // Arrange
        var controller = new FrogController();

        // Act
        var result = controller.Delete(nonExistingFrogID) as IActionResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }
}