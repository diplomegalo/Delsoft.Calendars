# Calendars

This librairy offers calendar features.

Choose your calendar properties with `Calendar.Now` for the current year, month and day or `Calendar.ForYear` for a specific year.

# Holiday

From a calendar instance, you can retrieve the date of holiday. The following code retreives the easter date of the year 2022 :  

```c#
var easter = Calendar.ForYear(2022).Easter()
```

> Until know, only officials belgian holidays are available.
