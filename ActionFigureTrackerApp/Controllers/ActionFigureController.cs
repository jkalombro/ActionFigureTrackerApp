using ActionFigureTrackerApp.Application.Dto;
using ActionFigureTrackerApp.Application.Services.Interfaces;
using ActionFigureTrackerApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ActionFigureTrackerApp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ActionFigureController : ControllerBase
  {
    private readonly IActionFigureService _actionFigureService;

    public ActionFigureController(IActionFigureService actionFigureService)
    {
      _actionFigureService = actionFigureService;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<ActionFigure>>> GetAllActionFigures()
    {
      var figure = await _actionFigureService.GetAll();

      return Ok(figure);
    }

    [HttpGet]
    [Route("{actionFigureId}")]
    public async Task<ActionResult<ActionFigure>> GetActionFigure([FromRoute] int actionFigureId)
    {
      var figure = await _actionFigureService.GetActionFigure(actionFigureId);

      if (figure == null)
        return NotFound("Action Figure not Found");

      return Ok(figure);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddActionFigure([FromBody] ActionFigureDto actionFigure)
    {
      await _actionFigureService.AddActionFigure(actionFigure);

      return Ok();
    }

    [HttpPut]
    [Route("{actionFigureId}")]
    public async Task<IActionResult> UpdateActionFigure([FromRoute] int actionFigureId, [FromBody] ActionFigureDto actionFigure)
    {
      try
      {
        await _actionFigureService.UpdateActionFigure(actionFigureId, actionFigure);
        return Ok();
      }
      catch (KeyNotFoundException ex)
      {
        return NotFound(ex.Message);
      }
    }
  }
}
