using ActionFigureTrackerApp.Application.Dto;
using ActionFigureTrackerApp.Core.Entities;
using AutoMapper;

namespace ActionFigureTrackerApp.Application.Utils
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<ActionFigureDto, ActionFigure>();
    }
  }
}
