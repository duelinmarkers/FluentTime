// Copyright 2011 ThoughtWorks, Inc. See LICENSE.txt for licensing info.
using System;

namespace FluentTime
{
	public struct VariableTimeSpan : IEquatable<VariableTimeSpan>
	{
		private const int MonthsInYear = 12;

		private readonly int years;
		private readonly int months;
		private readonly TimeSpan timeSpan;

		public VariableTimeSpan(int years, int months) : this(years, months, TimeSpan.Zero) {}
		
		public VariableTimeSpan(int years, int months, TimeSpan timeSpan)
		{
			this.years = years + (months / MonthsInYear);
			this.months = months % MonthsInYear;
			this.timeSpan = timeSpan;
		}
		
		public VariableTimeSpan AddTo(VariableTimeSpan other)
		{
			return new VariableTimeSpan(years + other.years, months + other.months, timeSpan + other.timeSpan);
		}
		
		public VariableTimeSpan AddTo(TimeSpan timeSpan)
		{
			return new VariableTimeSpan(years, months, this.timeSpan + timeSpan);
		}
		
		public DateTime AddTo(DateTime dateTime)
		{
			return dateTime.AddYears(years).AddMonths(months).Add(timeSpan);
		}
		
		public DateTimeOffset AddTo(DateTimeOffset dateTime)
		{
			return dateTime.AddYears(years).AddMonths(months).Add(timeSpan);
		}
		
		public DateTime After(DateTime dateTime)
		{
			return AddTo(dateTime);
		}
		
		public DateTimeOffset After(DateTimeOffset dateTime)
		{
			return AddTo(dateTime);
		}
		
		public static VariableTimeSpan operator +(VariableTimeSpan one, VariableTimeSpan other) { return one.AddTo(other); }
		
		public static VariableTimeSpan operator +(TimeSpan timeSpan, VariableTimeSpan v) { return v.AddTo(timeSpan); }
		public static VariableTimeSpan operator +(VariableTimeSpan v, TimeSpan timeSpan) { return v.AddTo(timeSpan); }

		public static DateTime operator +(VariableTimeSpan span, DateTime dateTime) { return span.AddTo(dateTime); }
		public static DateTime operator +(DateTime dateTime, VariableTimeSpan span) { return span.AddTo(dateTime); }
		
		public static DateTimeOffset operator +(VariableTimeSpan span, DateTimeOffset dateTime) { return span.AddTo(dateTime); }
		public static DateTimeOffset operator +(DateTimeOffset dateTime, VariableTimeSpan span) { return span.AddTo(dateTime); }

		public bool Equals(VariableTimeSpan other)
		{
			return months == other.months && years == other.years && timeSpan == other.timeSpan;
		}
		
		public override bool Equals(object obj)
		{
			if (!(obj is VariableTimeSpan))
				return false;
			return Equals((VariableTimeSpan)obj);
		}
		
		public override int GetHashCode()
		{
			return months.GetHashCode() ^ years.GetHashCode();
		}
		
		public static bool operator ==(VariableTimeSpan one, VariableTimeSpan other)
		{
			return one.Equals(other);
		}
		
		public static bool operator !=(VariableTimeSpan one, VariableTimeSpan other)
		{
			return !(one == other);
		}
	}
}
