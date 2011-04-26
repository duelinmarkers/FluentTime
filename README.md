FluentTime
==========

A fluent interface in .NET for working with dates and times, inspired by 
ActiveSupport's active_support/core_ext/numeric/time extensions.

Do stuff like this:

    var toothBrushingTime = 10.Minutes().Before(bedTime);
    var lightsOutForReal = 1.Hour(30.Minutes()).After(bedTime);
    ...
    Assert.That(actual, Is.LessThan(50.Milliseconds().After(expected)));
    ...
    var bestDaysOfMyLife = 30.days().Ago()

To Do
-----

"Abstract" time spans with variable-length calendar units like month, year, and quarter.
