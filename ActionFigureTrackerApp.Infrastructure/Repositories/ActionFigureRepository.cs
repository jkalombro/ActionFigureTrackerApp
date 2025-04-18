﻿using ActionFigureTrackerApp.Core.Entities;
using ActionFigureTrackerApp.Infrastructure.Data;

namespace ActionFigureTrackerApp.Infrastructure.Repositories
{
  public class ActionFigureRepository : BaseRepository<ActionFigure>, IActionFigureRepository
  {
    public ActionFigureRepository(DataContext context) : base(context)
    {
    }
  }
}
