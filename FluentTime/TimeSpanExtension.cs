using System;
namespace FluentTime
{
	public static class TimeSpanExtension
	{
		public static DateTime Before(this TimeSpan span, DateTime dateTime)
		{
			return dateTime - span;
		}
		
		public static DateTime After(this TimeSpan span, DateTime dateTime)
		{
			return dateTime + span;
		}
	}
}
