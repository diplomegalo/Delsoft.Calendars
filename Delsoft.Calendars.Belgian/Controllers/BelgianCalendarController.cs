using Microsoft.AspNetCore.Mvc;

namespace Delsoft.Calendars.Belgian.Controllers;

[ApiController]
[Route("api/calendar/belgian")]
public class BelgianCalendarController : ControllerBase
{
    private readonly ICalendarFactory<IBelgianCalendar> _calendarFactory;

    public BelgianCalendarController(ICalendarFactory<IBelgianCalendar> calendarFactory)
    {
        _calendarFactory = calendarFactory;
    }

    [HttpGet]
    [Route("holidays")]
    public IActionResult GetAll([FromQuery] int? year) =>
        this.Ok(_calendarFactory.Create(year).Holidays.GetAll());

    [HttpGet]
    [Route("holidays/{name}")]
    public IActionResult Get([FromQuery]int? year, string name) => this.Ok(_calendarFactory.Create(year).Holidays.Get(name));
}