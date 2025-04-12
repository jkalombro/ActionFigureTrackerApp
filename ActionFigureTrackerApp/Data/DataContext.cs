using ActionFigureTrackerApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActionFigureTrackerApp.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    public DbSet<ActionFigure> ActionFigures { get; set; }
  }
}
