# Holidays Calendar

## Create holiday calendar

Get holiday calendar by using `HolidayCalendar` class. This class contains all calendars. The following code retrieves the belgian holiday calendar. 

```c#
var cal = HolidayCalendar.Belgian
```

# Holiday

From a calendar instance, you can retrieve the date of a holiday. The following code retreives the easter date of the year 2022 :  

```c#
var easter = Calendar.ForYear(2022).Easter()
```

> Until know, only officials belgian holidays are available.
