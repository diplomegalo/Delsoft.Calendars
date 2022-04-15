using Delsoft.Agendas.Belgian.Calendars;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Delsoft.Agendas.Belgian.Controllers;

[ApiController]
[Route("api/agendas/belgian")]
public class BelgianCalendarController : ControllerBase
{
    private readonly IAgendaFactory<IBelgianAgenda> _agendaFactory;

    public BelgianCalendarController(IAgendaFactory<IBelgianAgenda> agendaFactory)
    {
        _agendaFactory = agendaFactory;
    }

    [HttpGet]
    [Route("calendars/legal-holidays")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetLegalHolidays([FromQuery] int? year) =>
        this.Ok(_agendaFactory.Create(year).GetAll(agenda => agenda.LegalHolidaysCalendar));

    [HttpGet]
    [Route("events/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get([FromQuery]int? year, string name) =>
        this.Ok(_agendaFactory.Create(year).BelgianHolidayCalendar.Get(name));
}