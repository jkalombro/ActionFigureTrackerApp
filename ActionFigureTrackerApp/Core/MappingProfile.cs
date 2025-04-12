using ActionFigureTrackerApp.Dto;
using ActionFigureTrackerApp.Entities;
using AutoMapper;

namespace ActionFigureTrackerApp.Core
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<ActionFigureDto, ActionFigure>();
    }
  }
}
