﻿namespace ActionFigureTrackerApp.Entities
{
  public class ActionFigure
  {
    public int ActionFigureId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? MediaType { get; set; }
    public string? MediaName { get; set; }
  }
}
