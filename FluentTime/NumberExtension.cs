// Copyright 2011 ThoughtWorks, Inc. See LICENSE.txt for licensing info.
using System;

namespace FluentTime
{
	public static class NumberExtension
	{
		public static TimeSpan Weeks(this double i) { return TimeSpan.FromDays(i * 7); }
		public static TimeSpan Days(this double i) { return TimeSpan.FromDays(i); }
		public static TimeSpan Hours(this double i) { return TimeSpan.FromHours(i); }
		public static TimeSpan Minutes(this double i) { return TimeSpan.FromMinutes(i); }
		public static TimeSpan Seconds(this double i) { return TimeSpan.FromSeconds(i); }
		public static TimeSpan Milliseconds(this double i) { return new TimeSpan((long)(TimeSpan.TicksPerMillisecond * i)); }
		public static TimeSpan Ticks(this long i) { return TimeSpan.FromTicks(i); }

		public static TimeSpan Week(this double i) { return Weeks(i); }
		public static TimeSpan Day(this double i) { return Days(i); }
		public static TimeSpan Hour(this double i) { return Hours(i); }
		public static TimeSpan Minute(this double i) { return Minutes(i); }
		public static TimeSpan Second(this double i) { return Seconds(i); }
		public static TimeSpan Millisecond(this double i) { return Milliseconds(i); }
		public static TimeSpan Tick(this long i) { return Ticks(i); }

		public static TimeSpan Weeks(this double i, TimeSpan otherTime) { return Weeks(i) + otherTime; }
		public static TimeSpan Days(this double i, TimeSpan otherTime) { return Days(i) + otherTime; }
		public static TimeSpan Hours(this double i, TimeSpan otherTime) { return Hours(i) + otherTime; }
		public static TimeSpan Minutes(this double i, TimeSpan otherTime) { return Minutes(i) + otherTime; }
		public static TimeSpan Seconds(this double i, TimeSpan otherTime) { return Seconds(i) + otherTime; }
		public static TimeSpan Milliseconds(this double i, TimeSpan otherTime) { return Milliseconds(i) + otherTime; }
		public static TimeSpan Ticks(this long i, TimeSpan otherTime) { return Ticks(i) + otherTime; }

		public static TimeSpan Week(this double i, TimeSpan otherTime) { return Weeks(i, otherTime); }
		public static TimeSpan Day(this double i, TimeSpan otherTime) { return Days(i, otherTime); }
		public static TimeSpan Hour(this double i, TimeSpan otherTime) { return Hours(i, otherTime); }
		public static TimeSpan Minute(this double i, TimeSpan otherTime) { return Minutes(i, otherTime); }
		public static TimeSpan Second(this double i, TimeSpan otherTime) { return Seconds(i, otherTime); }
		public static TimeSpan Millisecond(this double i, TimeSpan otherTime) { return Milliseconds(i, otherTime); }
		public static TimeSpan Tick(this long i, TimeSpan otherTime) { return Ticks(i, otherTime); }
	}
}
