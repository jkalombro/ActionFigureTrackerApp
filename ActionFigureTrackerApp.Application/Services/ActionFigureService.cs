using ActionFigureTrackerApp.Application.Dto;
using ActionFigureTrackerApp.Application.Services.Interfaces;
using ActionFigureTrackerApp.Core.Entities;
using ActionFigureTrackerApp.Core.Repositories;
using AutoMapper;

namespace ActionFigureTrackerApp.Application.Services
{
  public class ActionFigureService : IActionFigureService
  {
    private readonly IActionFigureRepository _repository;
    private readonly IMapper _mapper;

    public ActionFigureService(
      IActionFigureRepository repository,
      IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<List<ActionFigure>> GetAll()
    {
      return (await _repository.GetAllAsync())
        .ToList();
    }

    public async Task<ActionFigure?> GetActionFigure(int id)
    {
      return await _repository.GetByIdAsync(id);
    }

    public async Task AddActionFigure(ActionFigureDto actionFigure)
    {
      var figure = _mapper.Map<ActionFigure>(actionFigure);
      await _repository.AddAsync(figure);
    }

    public async Task UpdateActionFigure(int id, ActionFigureDto dto)
    {
      var actionFigure = await _repository.GetByIdAsync(id);
      if (actionFigure == null) throw new KeyNotFoundException("Action Figure not found");

      actionFigure.Name = dto.Name;
      actionFigure.Description = dto.Description;
      actionFigure.MediaType = dto.MediaType;
      actionFigure.MediaName = dto.MediaName;

      await _repository.UpdateAsync(actionFigure);
    }
  }
}
