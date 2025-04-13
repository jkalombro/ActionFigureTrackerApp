using ActionFigureTrackerApp.Application.Dto;
using ActionFigureTrackerApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFigureTrackerApp.Application.Services.Interfaces
{
  public interface IActionFigureService
  {
    Task<List<ActionFigure>> GetAll();
    Task<ActionFigure?> GetActionFigure(int id);
    Task AddActionFigure(ActionFigureDto dto);
    Task UpdateActionFigure(int id, ActionFigureDto dto);
  }
}
