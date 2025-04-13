using ActionFigureTrackerApp.Application.Dto;
using ActionFigureTrackerApp.Application.Services.Interfaces;
using ActionFigureTrackerApp.Controllers;
using ActionFigureTrackerApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ActionFigureTrackerApp.Tests.Controllers;

public class ActionFigureControllerTests : BaseIntegrationTest
{
  private readonly Mock<IActionFigureService> _mockActionFigureService;
  private readonly ActionFigureController _controller;

  public ActionFigureControllerTests()
    : base()
  {
    _mockActionFigureService = new Mock<IActionFigureService>();
    _controller = new ActionFigureController(_mockActionFigureService.Object);
  }

  [Fact]
  public async Task GetAllActionFigures_ReturnsOkResult_WithListOfActionFigures()
  {
    // Arrange
    var actionFigures = new List<ActionFigure>
        {
            new ActionFigure { ActionFigureId = 1, Name = "Figure1" },
            new ActionFigure { ActionFigureId = 2, Name = "Figure2" }
        };
    _mockActionFigureService.Setup(service => service.GetAll())
        .ReturnsAsync(actionFigures);

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
    _mockActionFigureService.Setup(service => service.GetActionFigure(1))
        .ReturnsAsync(actionFigure);

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
    // Arrange
    _mockActionFigureService.Setup(service => service.GetActionFigure(1))
        .ReturnsAsync((ActionFigure?)null);

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
    _mockActionFigureService.Setup(service => service.AddActionFigure(actionFigureDto))
        .Returns(Task.CompletedTask);

    // Act
    var result = await _controller.AddActionFigure(actionFigureDto);

    // Assert
    Assert.IsType<OkResult>(result);
    _mockActionFigureService.Verify(service => service.AddActionFigure(actionFigureDto), Times.Once);
  }

  [Fact]
  public async Task UpdateActionFigure_ReturnsOkResult_WhenActionFigureExists()
  {
    // Arrange
    var actionFigureDto = new ActionFigureDto { Name = "UpdatedFigure" };
    _mockActionFigureService.Setup(service => service.UpdateActionFigure(1, actionFigureDto))
        .Returns(Task.CompletedTask);

    // Act
    var result = await _controller.UpdateActionFigure(1, actionFigureDto);

    // Assert
    Assert.IsType<OkResult>(result);
    _mockActionFigureService.Verify(service => service.UpdateActionFigure(1, actionFigureDto), Times.Once);
  }

  [Fact]
  public async Task UpdateActionFigure_ReturnsNotFound_WhenActionFigureDoesNotExist()
  {
    // Arrange
    var actionFigureDto = new ActionFigureDto { Name = "PlaceholderName" };
    _mockActionFigureService.Setup(service => service.UpdateActionFigure(1, actionFigureDto))
        .ThrowsAsync(new KeyNotFoundException("Action Figure not found"));

    // Act
    var result = await _controller.UpdateActionFigure(1, actionFigureDto);

    // Assert
    Assert.IsType<NotFoundObjectResult>(result);
  }
}
