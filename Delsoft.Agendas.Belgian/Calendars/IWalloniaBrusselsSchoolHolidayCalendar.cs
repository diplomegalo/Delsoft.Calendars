using Delsoft.Agendas.Calendars;
using Delsoft.Agendas.Models;

namespace Delsoft.Agendas.Belgian.Calendars;

public interface IWalloniaBrusselsSchoolHolidayCalendar: ICustomCalendar
{
    Event FrenchCommunityHoliday { get; }

    Event AutumnHoliday { get;  }

    Event CommemorationOf11November { get; }
}