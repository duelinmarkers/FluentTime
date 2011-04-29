// Copyright 2011 ThoughtWorks, Inc. See LICENSE.txt for licensing info.
using System;

namespace FluentTime
{
	public struct VariableTimeSpan : IEquatable<VariableTimeSpan>
	{
		private readonly int years;
		private readonly int months;

		public VariableTimeSpan (int years, int months)
		{
			this.years = years + (months / 12);
			this.months = months % 12;
		}
		
		public DateTime AddTo(DateTime dateTime)
		{
			return dateTime.AddYears(years).AddMonths(months);
		}
		
		public DateTimeOffset AddTo(DateTimeOffset dateTime)
		{
			return dateTime.AddYears(years).AddMonths(months);
		}
		
		public DateTime After(DateTime dateTime)
		{
			return AddTo(dateTime);
		}
		
		public DateTimeOffset After(DateTimeOffset dateTime)
		{
			return AddTo(dateTime);
		}
		
		public static DateTime operator +(VariableTimeSpan span, DateTime dateTime)
		{
			return span.After(dateTime);
		}
		
		public static DateTime operator +(DateTime dateTime, VariableTimeSpan span)
		{
			return span.After(dateTime);
		}
		
		public static DateTimeOffset operator +(VariableTimeSpan span, DateTimeOffset dateTime)
		{
			return span.After(dateTime);
		}
		
		public static DateTimeOffset operator +(DateTimeOffset dateTime, VariableTimeSpan span)
		{
			return span.After(dateTime);
		}
		
		public bool Equals(VariableTimeSpan other)
		{
			return months == other.months && years == other.years;
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
