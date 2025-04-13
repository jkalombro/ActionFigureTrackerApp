namespace ActionFigureTrackerApp.Application.Dto
{
  public class ActionFigureDto
  {
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? MediaType { get; set; }
    public string? MediaName { get; set; }
  }
}
