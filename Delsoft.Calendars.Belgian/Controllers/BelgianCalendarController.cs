using Microsoft.AspNetCore.Mvc;

namespace Delsoft.Calendars.Belgian.Controllers;

[ApiController]
[Route("api/calendar/belgian")]
public class BelgianCalendarController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => this.Ok(CalendarFactory.Create<BelgianCalendar>().Holidays);
}