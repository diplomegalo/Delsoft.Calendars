using System;
using System.Collections.Generic;
using Delsoft.Holidays.Calendars;
using Delsoft.Holidays.Models;

namespace Delsoft.Holidays.Test.Stubs;

internal class HolidayCalendarStub : HolidayCalendar<HolidayCalendarStub>
{
    public static DateTime Holiday1Date = DateTime.Today.AddDays(1);
    public static string Holiday1Name = nameof(Holiday1Name);
    public static string Holiday1LocalName = nameof(Holiday1LocalName);
    
    public static DateTime Holiday2Date = DateTime.Today;
    public static string Holiday2Name = nameof(Holiday2Name);
    public static string Holiday2LocalName = nameof(Holiday2LocalName);
    
    public HolidayCalendarStub()
    {
    }

    public HolidayCalendarStub(int year) => Year = year;

    public Holiday Holiday1 => new()
    {
        Date = Holiday1Date,
        Name = Holiday1Name,
        LocalName = Holiday1LocalName
    };
    
    public Holiday Holiday2 => new()
    {
        Date = Holiday2Date,
        Name = Holiday2Name,
        LocalName = Holiday2LocalName
    };

    public override string[] GetCultures() => Array.Empty<string>();

    public override IEnumerable<Holiday> GetAll() => Get(stub => stub.Holiday1, stub => stub.Holiday2);
}