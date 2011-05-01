// Copyright 2011 ThoughtWorks, Inc. See LICENSE.txt for licensing info.
using System;

namespace FluentTime
{
	public static class DateTimeOffsetting
	{
		public static DateTimeOffset Offset(this DateTime d, int hours)
		{
			return Offset(d, TimeSpan.FromHours(hours));
		}
		
		public static DateTimeOffset Offset(this DateTime d, TimeSpan offset)
		{
			return new DateTimeOffset(d, offset);
		}
	}
}
