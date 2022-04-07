# Holidays Calendar

This library offers a mean to retrieve holidays for a specific year. 

Holidays can be get through calendars. A calendar is a group of holidays. The available calendars are placed in the `Delsoft.Holidays.Calendars` namespace.

## Create a calendar

Get holiday calendar by using the static method `Create` of the `HolidayCalendar` class with the type of calendar as generic type parameter of the method.

```c#
IBelgianHolidayCalendar calendar = HolidayCalendar.Create<Calendars.BelgianHolidayCalendar>();
```

You can choose a specific year for the calendar by passing the value as parameter.  

```c#
var calendar = HolidayCalendar.Create<BelgianHolidayCalendar>(2002);
```

## Holiday

### Holiday property
A calendar defines properties returning a `Holiday` object. The `Holiday` model defines the `Date`, the `Name` and the `LocalName` of the holiday. The `LocalName` depends on the `CurrentUICulture` value of the current thread.  

```c#
var calendar = HolidayCalendar.Create<BelgianHolidayCalendar>();
var holiday = calendar.NewYear;
```

### Set of holidays
You can retrieve a list of holidays by using the `GetAll` or the `Get` method.

The `Get` method allows you to select a custom subset of `Holiday` by passing wanted properties as parameters.

```c#
var calendar = HolidayCalendar.Create<BelgianHolidayCalendar>();
var subset = calendar.Get(cal => cal.LaborDay, cal => cal.Easter);
```

## Localisation

You can localize the `LocalName` value of the `Holiday` by setting the `CurrentUICulture` value. The culture available are depending on the calendar.

```c#
// Get available cultures for a calendar
var calendar = HolidayCalendar.Create<BelgianHolidayCalendar>();
var culture = calendar.GetCultures()[0];

// Overrides the current value of the UI culture with a specific value.
CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);

// Get the local name of the holiday
var holiday = calendar.NewYear;
var localName = holiday.LocalName;
```

## Holiday Calendar

Calendars are stored in the `Delsoft.Holidays.Calendars`. Each of them are specifics and gathers a set of holiday. They can own a reference to another calendar which can be considered as a subset of the calendar.

For example, the specific calendar of a country might own references to calendars of its regions as the Belgian calendar might owns the Flanders, the Wallonia and the German-speaking community calendars.

### Belgian Holiday Calendar


