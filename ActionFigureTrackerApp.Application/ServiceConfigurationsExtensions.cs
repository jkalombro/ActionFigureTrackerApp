using ActionFigureTrackerApp.Application.Services;
using ActionFigureTrackerApp.Application.Services.Interfaces;
using ActionFigureTrackerApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ActionFigureTrackerApp.Application
{
  public static class ServiceConfigurationsExtensions
  {
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
      services.AddScoped<IActionFigureRepository, ActionFigureRepository>();

      return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
      services.AddScoped<IActionFigureService, ActionFigureService>();

      return services;
    }
  }
}
