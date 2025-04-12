using ActionFigureTrackerApp.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace ActionFigureTrackerApp.Tests
{
  public class BaseIntegrationTest : IAsyncLifetime
  {
    protected readonly DataContext _dataContext;
    protected readonly Mock<IMapper> _mockMapper;

    public BaseIntegrationTest()
    {
      // Configure in-memory database
      var options = new DbContextOptionsBuilder<DataContext>()
          .UseInMemoryDatabase(databaseName: "TestDb")
          .Options;

      _dataContext = new DataContext(options);
      _mockMapper = new Mock<IMapper>();
    }

    public Task InitializeAsync()
    {
      // Clear database before each test
      _dataContext.ActionFigures.RemoveRange(_dataContext.ActionFigures);
      return _dataContext.SaveChangesAsync();
    }

    public Task DisposeAsync()
    {
      // Cleanup logic if needed
      return Task.CompletedTask;
    }
  }
}
