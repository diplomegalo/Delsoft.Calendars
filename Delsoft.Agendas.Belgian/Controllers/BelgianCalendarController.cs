using Delsoft.Calendars.Belgian;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Delsoft.Agendas.Belgian.Controllers;

[ApiController]
[Route("api/agenda/belgian")]
public class BelgianCalendarController : ControllerBase
{
    private readonly IAgendaFactory<IBelgianAgenda> _agendaFactory;

    public BelgianCalendarController(IAgendaFactory<IBelgianAgenda> agendaFactory)
    {
        _agendaFactory = agendaFactory;
    }

    [HttpGet]
    [Route("holidays")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAll([FromQuery] int? year) =>
        this.Ok(_agendaFactory.Create(year).Holidays.GetAll());

    [HttpGet]
    [Route("holidays/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get([FromQuery]int? year, string name) => this.Ok(_agendaFactory.Create(year).Holidays.Get(name));
}