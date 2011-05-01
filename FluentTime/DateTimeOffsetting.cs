// Copyright 2011 ThoughtWorks, Inc. See LICENSE.txt for licensing info.
using System;

namespace FluentTime
{
	public static class DateTimeOffsetting
	{
		public static DateTimeOffset Offset(this DateTime d, TimeSpan offset)
		{
			return new DateTimeOffset(d, offset);
		}
		
		public static DateTimeOffset Offset(this DateTime d, int hours)
		{
			return d.Offset(TimeSpan.FromHours(hours));
		}
		
		public static DateTimeOffset OffsetFor(this DateTime d, TimeZoneInfo zone)
		{
			return d.Offset(zone.GetUtcOffset(d));
		}
		
		public static DateTimeOffset OffsetFor(this DateTime d, string timeZoneId)
		{
			return d.OffsetFor(TimeZoneInfo.FindSystemTimeZoneById(timeZoneId));
		}
		
		public static DateTimeOffset OffsetForLocal(this DateTime d)
		{
			return d.OffsetFor(TimeZoneInfo.Local);
		}
	}
}
