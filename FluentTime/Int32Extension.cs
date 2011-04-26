using System;
namespace FluentTime
{
	public static class Int32Extension
	{
		public static TimeSpan Days(this int i) { return TimeSpan.FromDays(i); }
		public static TimeSpan Hours(this int i) { return TimeSpan.FromHours(i); }
		public static TimeSpan Minutes(this int i) { return TimeSpan.FromMinutes(i); }
		public static TimeSpan Seconds(this int i) { return TimeSpan.FromSeconds(i); }
		public static TimeSpan Milliseconds(this int i) { return TimeSpan.FromMilliseconds(i); }
		public static TimeSpan Ticks(this int i) { return TimeSpan.FromTicks(i); }

		public static TimeSpan Day(this int i) { return Days(i); }
		public static TimeSpan Hour(this int i) { return Hours(i); }
		public static TimeSpan Minute(this int i) { return Minutes(i); }
		public static TimeSpan Second(this int i) { return Seconds(i); }
		public static TimeSpan Millisecond(this int i) { return Milliseconds(i); }
		public static TimeSpan Tick(this int i) { return Ticks(i); }
	}
}
