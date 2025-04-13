using ActionFigureTrackerApp.Application.Dto;
using ActionFigureTrackerApp.Core.Entities;
using ActionFigureTrackerApp.Infrastructure.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActionFigureTrackerApp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ActionFigureController : ControllerBase
  {
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public ActionFigureController(DataContext dataContext, IMapper mapper)
    {
      _dataContext = dataContext;
      _mapper = mapper;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<ActionFigure>>> GetAllActionFigures()
    {
      var figure = await _dataContext.ActionFigures.ToListAsync();

      return Ok(figure);
    }

    [HttpGet]
    [Route("{actionFigureId}")]
    public async Task<ActionResult<ActionFigure>> GetActionFigure([FromRoute] int actionFigureId)
    {
      var figure = await _dataContext.ActionFigures.FindAsync(actionFigureId);

      if (figure == null)
        return NotFound("Action Figure not Found");

      return Ok(figure);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddActionFigure([FromBody] ActionFigureDto actionFigure)
    {
      var figure = _mapper.Map<ActionFigure>(actionFigure);
      _dataContext.ActionFigures.Add(figure);
      await _dataContext.SaveChangesAsync();

      return Ok();
    }

    [HttpPut]
    [Route("{actionFigureId}")]
    public async Task<IActionResult> UpdateActionFigure([FromRoute] int actionFigureId, [FromBody] ActionFigureDto actionFigure)
    {
      var figure = await _dataContext.ActionFigures.FindAsync(actionFigureId);

      if (figure == null)
        return NotFound("Action Figure not Found");

      figure.Name = actionFigure.Name;
      figure.Description = actionFigure.Description;
      figure.MediaType = actionFigure.MediaType;
      figure.MediaName = actionFigure.MediaName;

      await _dataContext.SaveChangesAsync();

      return Ok();
    }
  }
}
