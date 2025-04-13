using ActionFigureTrackerApp.Application.Dto;
using ActionFigureTrackerApp.Controllers;
using ActionFigureTrackerApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ActionFigureTrackerApp.Tests.Controllers;

public class ActionFigureControllerTests : BaseIntegrationTest
{
  private readonly ActionFigureController _controller;

  public ActionFigureControllerTests()
    : base()
  {
    _controller = new ActionFigureController(_dataContext, _mockMapper.Object);
  }

  [Fact]
  public async Task GetAllActionFigures_ReturnsOkResult_WithListOfActionFigures()
  {
    // Arrange
    _dataContext.ActionFigures.AddRange(
        new ActionFigure { ActionFigureId = 1, Name = "Figure1" },
        new ActionFigure { ActionFigureId = 2, Name = "Figure2" }
    );
    await _dataContext.SaveChangesAsync();

    // Act
    var result = await _controller.GetAllActionFigures();

    // Assert
    var okResult = Assert.IsType<OkObjectResult>(result.Result);
    var returnedFigures = Assert.IsType<List<ActionFigure>>(okResult.Value);
    Assert.Equal(2, returnedFigures.Count);
  }

  [Fact]
  public async Task GetActionFigure_ReturnsOkResult_WithActionFigure()
  {
    // Arrange
    var actionFigure = new ActionFigure { ActionFigureId = 1, Name = "Figure1" };
    _dataContext.ActionFigures.Add(actionFigure);
    await _dataContext.SaveChangesAsync();

    // Act
    var result = await _controller.GetActionFigure(1);

    // Assert
    var okResult = Assert.IsType<OkObjectResult>(result.Result);
    var returnedFigure = Assert.IsType<ActionFigure>(okResult.Value);
    Assert.Equal("Figure1", returnedFigure.Name);
  }

  [Fact]
  public async Task GetActionFigure_ReturnsNotFound_WhenActionFigureDoesNotExist()
  {
    // Act
    var result = await _controller.GetActionFigure(1);

    // Assert
    Assert.IsType<NotFoundObjectResult>(result.Result);
  }

  [Fact]
  public async Task AddActionFigure_ReturnsOkResult()
  {
    // Arrange
    var actionFigureDto = new ActionFigureDto { Name = "NewFigure" };
    var actionFigure = new ActionFigure { Name = "NewFigure" };
    _mockMapper.Setup(x => x.Map<ActionFigure>(actionFigureDto))
        .Returns(actionFigure);

    // Act
    var result = await _controller.AddActionFigure(actionFigureDto);

    // Assert
    Assert.IsType<OkResult>(result);
    Assert.Single(_dataContext.ActionFigures);
  }

  [Fact]
  public async Task UpdateActionFigure_ReturnsOkResult_WhenActionFigureExists()
  {
    // Arrange
    var actionFigure = new ActionFigure { ActionFigureId = 1, Name = "OldFigure" };
    _dataContext.ActionFigures.Add(actionFigure);
    await _dataContext.SaveChangesAsync();

    var actionFigureDto = new ActionFigureDto { Name = "UpdatedFigure" };

    // Act
    var result = await _controller.UpdateActionFigure(1, actionFigureDto);

    // Assert
    Assert.IsType<OkResult>(result);
    Assert.Equal("UpdatedFigure", actionFigure.Name);
  }

  [Fact]
  public async Task UpdateActionFigure_ReturnsNotFound_WhenActionFigureDoesNotExist()
  {
    // Act
    var result = await _controller.UpdateActionFigure(1, new ActionFigureDto { Name = "PlaceholderName" });

    // Assert
    Assert.IsType<NotFoundObjectResult>(result);
  }
}
