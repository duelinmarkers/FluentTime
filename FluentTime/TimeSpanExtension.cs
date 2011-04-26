using System;
namespace FluentTime
{
	public static class TimeSpanExtension
	{
		public static DateTime       Before(this TimeSpan span, DateTime dateTime)       { return dateTime - span; }
		public static DateTimeOffset Before(this TimeSpan span, DateTimeOffset dateTime) { return dateTime - span; }
		public static DateTimeOffset Ago(this TimeSpan span) { return Before(span, DateTimeOffset.Now); }
		
		public static DateTime       After(this TimeSpan span, DateTime dateTime)       { return dateTime + span; }
		public static DateTimeOffset After(this TimeSpan span, DateTimeOffset dateTime) { return dateTime + span; }
		public static DateTimeOffset FromNow(this TimeSpan span) { return After(span, DateTimeOffset.Now); }
	}
}
