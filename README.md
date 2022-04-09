# Delsoft.Calendar

This library offers a means to
- retrieve holidays calendar 

for a specific year.

## Create a calendar

Create a calendar by using the static method `Create` of the `CalendarFactory` class with the type of calendar you want as generic type parameter of the method.

```c#
var calendar = CalendarFactory.Create<BelgianCalendar>();
```

You can choose a specific year for the calendar by passing the value as parameter.  

```c#
var calendar = CalendarFactory.Create<BelgianCalendar>(2002);
```

## Holidays Calendar

The `BaseCalendar` class defines the `Holidays` property which returns a `HolidaysCalendar`. A `HolidaysCalendar` gather a set of properties of specific holidays.

```c#
var holidaysCalendar = calendar.Holidays
```

Properties of `HolidaysCalendar` returns a `Holiday` object. The `Holiday` model defines 
- The `Date` property which contains the date of the holidays, 
- The `Name` property which contains the name of the holidays
- The `LocalName` method which returns the localized name of the holidays. 

The `LocalName` depends on the `CurrentUICulture` value of the current thread.  

```c#
CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");
var easter = calendar.Holidays.Easter;
Console.WriteLine($"{easter.Name} happens on {easter.Date.ToShortDateString()} and is said {easter.LocalName()} in {CultureInfo.CurrentUICulture.EnglishName}");

/*
 * Produces the following output:
 * Easter happens on 17/04/2022 and is said Pâques in French (France)
 */
```

### Set of holidays
You can retrieve a list of holidays by using the `GetAll` or the `Get` method.

The `Get` method allows you to select a custom subset of `Holiday` by passing wanted properties as parameters.

```c#
var subset = holidaysCalendar.Get(cal => cal.LaborDay, cal => cal.Easter);
```

### Localisation

You can localize the `LocalName` value of the `Holiday` by setting the `CurrentUICulture` value. The culture available are depending on the calendar.

```c#
foreach (var holiday in calendar.Holidays.GetAll())
{
    var line = $"{holiday.Name}: {holiday.Date.ToShortDateString()}{Environment.NewLine}";
    foreach (var culture in calendar.Holidays.GetCultures())
    {
        CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);
        line += $"\t{culture}: {holiday.LocalName()}{Environment.NewLine}";
    }
    Console.WriteLine(line);
}
```
