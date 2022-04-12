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
    public IActionResult GetAll() => this.Ok(_calendarFactory.Create().Holidays.GetAll());

    [HttpGet]
    [Route("holidays/{year}")]
    public IActionResult GetAll(int year) => this.Ok(_calendarFactory.Create(year).Holidays.GetAll());

    [HttpGet]
    [Route("holidays/{year}/{name}")]
    public IActionResult Get(int year, string name) => this.Ok(_calendarFactory.Create(year).Holidays.Get(name));

    [HttpGet]
    [Route("holidays/{name}")]
    public IActionResult Get(string name) => this.Ok(_calendarFactory.Create().Holidays.Get(name));
}