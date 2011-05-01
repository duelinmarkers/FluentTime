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
    var bestDaysOfMyLife = 30.Days().Ago();
    ...
    var movingAppointment = 15.May(2011).At(2).PM();

The "Before" and "After" stuff supports both DateTime and DateTimeOffset and
returns the same type you start with. The Offset of the input DateTimeOffset is
maintained.

Look at the tests for details.

---

Copyright 2011 ThoughtWorks, Inc. See LICENSE.txt for licensing info.