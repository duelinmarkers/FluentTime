// Copyright 2011 ThoughtWorks, Inc. See LICENSE.txt for licensing info.
using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace FluentTime.Tests
{
	[TestFixture]
	public class DateTimeCreationTest
	{
		[Test]
		public void Creates_dates_readably_with_month_methods ()
		{
			Assert.That(1.January(2001),    Is.EqualTo(new DateTime(2001, 1, 1)));
			Assert.That(11.February(2011),  Is.EqualTo(new DateTime(2011, 2, 11)));
			Assert.That(15.March(2011),     Is.EqualTo(new DateTime(2011, 3, 15)));
			Assert.That(6.April(2011),      Is.EqualTo(new DateTime(2011, 4, 6)));
			Assert.That(8.May(2011),        Is.EqualTo(new DateTime(2011, 5, 8)));
			Assert.That(14.June(2011),      Is.EqualTo(new DateTime(2011, 6, 14)));
			Assert.That(4.July(2011),       Is.EqualTo(new DateTime(2011, 7, 4)));
			Assert.That(21.August(2011),    Is.EqualTo(new DateTime(2011, 8, 21)));
			Assert.That(22.September(2011), Is.EqualTo(new DateTime(2011, 9, 22)));
			Assert.That(31.October(2011),   Is.EqualTo(new DateTime(2011, 10, 31)));
			Assert.That(10.November(2011),  Is.EqualTo(new DateTime(2011, 11, 10)));
			Assert.That(25.December(2011),  Is.EqualTo(new DateTime(2011, 12, 25)));
		}
		
		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Throws_ArgumentOutOfRangeException_on_invalid_dates ()
		{
			30.February(2010);
		}
		
		[Test]
		public void Time_can_be_specified_with_At ()
		{
			Assert.That(1.January(2001).At(11),         Is.EqualTo(new DateTime(2001, 1, 1, 11, 0, 0)));
			Assert.That(1.January(2001).At(12, 06),     Is.EqualTo(new DateTime(2001, 1, 1, 12, 6, 0)));
			Assert.That(1.January(2001).At(13, 30, 22), Is.EqualTo(new DateTime(2001, 1, 1, 13, 30, 22)));
		}
		
		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Throws_ArgumentOutOfRangeException_on_too_high_hour () { 1.January(2010).At(24); }
		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Throws_ArgumentOutOfRangeException_on_too_low_hour () { 1.January(2010).At(-1); }
		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Throws_ArgumentOutOfRangeException_on_too_high_minute () { 1.January(2010).At(11, 60); }
		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Throws_ArgumentOutOfRangeException_on_too_low_minute () { 1.January(2010).At(11, -1); }
		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Throws_ArgumentOutOfRangeException_on_too_high_second () { 1.January(2010).At(23, 59, 60); }
		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Throws_ArgumentOutOfRangeException_on_too_low_second () { 1.January(2010).At(23, 59, -1); }

		[Test]
		public void PM_adds_twelve_hours_to_a_twelve_hour_time ()
		{
			Assert.That(1.January(2001).At(10).PM(), Is.EqualTo(new DateTime(2001, 1, 1, 22, 0, 0)));
		}

		[Test]
		public void PM_does_nothing_with_hour_of_12 ()
		{
			Assert.That(1.January(2001).At(12).PM(), Is.EqualTo(new DateTime(2001, 1, 1, 12, 0, 0)));
		}
		
		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void PM_throws_with_hour_greater_than_12 ()
		{
			1.January(2001).At(13).PM();
		}

		[Test]
		public void AM_subtracts_twelve_hours_from_a_twelve_hour_time_with_hour_of_12 ()
		{
			Assert.That(1.January(2001).At(12).AM(), Is.EqualTo(new DateTime(2001, 1, 1, 0, 0, 0)));
		}

		[Test]
		public void AM_does_nothing_to_a_twelve_hour_time_with_hour_less_than_12 ()
		{
			Assert.That(1.January(2001).At(11).AM(), Is.EqualTo(new DateTime(2001, 1, 1, 11, 0, 0)));
		}
		
		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void AM_throws_with_hour_greater_than_12 ()
		{
			1.January(2001).At(13).AM();
		}
		
		[Test]
		public void Created_dates_have_Kind_Unspecified_by_default ()
		{
			Assert.That(5.January(2011).Kind, Is.EqualTo(DateTimeKind.Unspecified));
		}
		
		[Test]
		public void DateTimeKind_can_be_specified ()
		{
			Assert.That(5.January(2011).At(10, 15).Utc(),   Is.EqualTo(new DateTime(2011, 1, 5, 10, 15, 0, DateTimeKind.Utc)));
			Assert.That(5.January(2011).At(10, 15).Local(), Is.EqualTo(new DateTime(2011, 1, 5, 10, 15, 0, DateTimeKind.Local)));
		}
	}
}
