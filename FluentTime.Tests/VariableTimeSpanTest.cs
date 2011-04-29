// Copyright 2011 ThoughtWorks, Inc. See LICENSE.txt for licensing info.
using System;
using NUnit.Framework;

namespace FluentTime.Tests
{
	[TestFixture]
	public class VariableTimeSpanTest
	{
		[Test]
		public void AddTo_After_and_op_Addition_with_DateTime_are_all_the_same ()
		{
			var twoMonths = new VariableTimeSpan(0, 2);
			var date = new DateTime(2011, 2, 11);
			var expectedDate = new DateTime(2011, 4, 11);
			Assert.AreEqual(expectedDate, twoMonths.AddTo(date));
			Assert.AreEqual(expectedDate, twoMonths.After(date));
			Assert.AreEqual(expectedDate, twoMonths + date);
		}
		
		[Test]
		public void AddTo_After_and_op_Addition_with_DateTimeOffset_are_all_the_same ()
		{
			var twoMonths = new VariableTimeSpan(0, 2);
			var date = DateTimeOffset.Parse("2011/02/11 11:35 +2");
			var expectedDate = DateTimeOffset.Parse("2011/04/11 11:35 +2");
			Assert.AreEqual(expectedDate, twoMonths.AddTo(date));
			Assert.AreEqual(expectedDate, twoMonths.After(date));
			Assert.AreEqual(expectedDate, twoMonths + date);
		}
		
		[Test]
		public void Should_add_months_to_a_DateTime_in_both_directions ()
		{
			var twoMonths = new VariableTimeSpan(0, 2);
			Assert.AreEqual(new DateTime(2011, 4, 28),
			                twoMonths + new DateTime(2011, 2, 28));
			Assert.AreEqual(new DateTime(2011, 4, 28),
			                new DateTime(2011, 2, 28) + twoMonths);
		}
		
		[Test]
		public void Should_add_years_to_a_DateTime ()
		{
			var twoYears = new VariableTimeSpan(2, 0);
			Assert.AreEqual(new DateTime(2013, 4, 28),
			                twoYears + new DateTime(2011, 4, 28));
		}

		[Test]
		public void Should_add_months_to_a_DateTimeOffset_in_both_directions ()
		{
			var twoMonths = new VariableTimeSpan(0, 2);
			Assert.AreEqual(DateTimeOffset.Parse("2011/04/28 12:17:00 AM -4:00"),
			                twoMonths + DateTimeOffset.Parse("2011/02/28 12:17:00 AM -4:00"));
		}
		
		[Test]
		public void Should_add_years_to_a_DateTimeOffset ()
		{
			var twoYears = new VariableTimeSpan(2, 0);
			Assert.AreEqual(DateTimeOffset.Parse("2013/02/28 12:17:00 AM -4:00"),
			                twoYears + DateTimeOffset.Parse("2011/02/28 12:17:00 AM -4:00"));
			Assert.AreEqual(DateTimeOffset.Parse("2013/02/28 12:17:00 AM -4:00"),
			                DateTimeOffset.Parse("2011/02/28 12:17:00 AM -4:00") + twoYears);
		}
		
		[Test]
		public void Should_add_months_and_years_to_a_DateTime ()
		{
			var oneYearOneMonth = new VariableTimeSpan(1, 1);
			Assert.AreEqual(new DateTime(2011, 4, 28), 
			                oneYearOneMonth.AddTo(new DateTime(2010, 3, 28)));
		}
		
		[Test]
		public void Should_add_months_and_years_to_a_DateTimeOffset ()
		{
			var oneYearOneMonth = new VariableTimeSpan(1, 1);
			Assert.AreEqual(DateTimeOffset.Parse("2011/02/28 12:17:00 AM -4:00"), 
			                oneYearOneMonth.AddTo(DateTimeOffset.Parse("2010/01/28 12:17:00 AM -4:00")));
		}
	}
}
