# Delsoft.Agenda

This library provides a set of specific agenda around themes like country, company, religious, etc. Agenda offers a set of different calendars of recurrent, computable, date specifics to a topic. 

Below the list of current available agenda:
- `BelgianAgenda`: this agenda offers a set of calendars related to the belgian country as official holidays, school holiday, etc.

## Create an agenda

You can create an agenda by using the static method `Create` of the `AgendaFactory`, with the type or interface of the agenda you want create as generic type parameter of the method.

```c#
var agenda = AgendaFactory.Create<IBelgianAgenda>();
```

You can choose a specific year for the calendar by passing the value as parameter.

```c#
var agenda = AgendaFactory.Create<IBelgianAgenda>(2002);
```

## Custom Calendar

Each `Agenda` defines its own set of `CustomCalendar`. A `CustomCalendar` gather specific `Event`.

```c#
// Retrieves the specific BelgianHolidaysCalendar class which defines as set of holidays event.
var holidaysCalendar = agenda.Holidays;

// Acces properties of the specific BelgianHolidaysCalendar
var easterHolidays = holidaysCalendar.Easter;
var laborDayHolidays = holidaysCalendar.LaborDay;
```

The `Event` model defines 
- The `StartDate` property which contains the start date of the event,
- The `EndDate` property which contains the end date of the event,
- The `Name` property which contains the name of the holidays
- The `LocalName` method which returns the localized name of the holidays.

The `LocalName` depends on the `CurrentUICulture` value of the current thread.

> For one day events, the `StartDate` and the `EndDate` values are the same.

```c#
CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");
var easter = agenda.Holidays.Easter;
Console.WriteLine($"{easter.Name} happens on {easter.Date.ToShortDateString()} and is said {easter.LocalName()} in {CultureInfo.CurrentUICulture.EnglishName}");

/*
 * Produces the following output:
 * Easter happens on 17/04/2022 and is said Pâques in French (France)
 */
```

### Set of holidays
You can retrieve a list of `Event` by using the `GetAll` or the `Get` method.

The `Get` method allows you to select a custom subset of `Event`, 

- either by passing wanted properties as parameters:

```c#
var subset = holidaysCalendar.Get(cal => cal.LaborDay, cal => cal.Easter);
```

- either by passing the name of the holidays as parameters:

```c#
var subset = holidaysCalendar.Get("Labor Day", "Easter");
```

> `Get(params string[] args)` method returns a `EventNotFoundException` when the name of the event isn't found in the set of properties.

### Localisation

You can localize the `LocalName` value of the `Event` by setting the `CurrentUICulture` value. The culture available are depending on the calendar.

```c#
foreach (var holiday in agenda.Holidays.GetAll())
{
    var line = $"{holiday.Name}: {holiday.StartDate.ToShortDateString()}{Environment.NewLine}";
    foreach (var culture in calendar.Holidays.GetCultures())
    {
        CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);
        line += $"\t{culture}: {holiday.LocalName()}{Environment.NewLine}";
    }
    Console.WriteLine(line);
}
```

# Belgian Agenda

## Web API
Integrate the `BelgianAgenda` to a Web API project by using the `AddBelgianAgendaController` method as below: 

```c#
builder.Services.AddControllers()
    .AddBelgianAgendaController();
```
