using ActionFigureTrackerApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActionFigureTrackerApp.Infrastructure.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    public DbSet<ActionFigure> ActionFigures { get; set; }
  }
}
