// Copyright 2011 ThoughtWorks, Inc. See LICENSE.txt for licensing info.
using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace FluentTime.Tests
{
	[TestFixture]
	public class VariableTimeSpanTest
	{
		[Test]
		public void Adds_two_VariableTimeSpans ()
		{
			Assert.That(2.Years() + 3.Months(), Is.EqualTo(new VariableTimeSpan(2, 3)));
			Assert.That(1.Year() + 2.Years(), Is.EqualTo(3.Years()));
		}

		[Test]
		public void DateTime_AddTo_After_and_op_Addition_are_all_the_same ()
		{
			var twoMonths = new VariableTimeSpan(0, 2);
			var date = new DateTime(2011, 2, 11);
			var expectedDate = new DateTime(2011, 4, 11);
			Assert.AreEqual(expectedDate, twoMonths.AddTo(date));
			Assert.AreEqual(expectedDate, twoMonths.After(date));
			Assert.AreEqual(expectedDate, twoMonths + date);
		}
		
		[Test]
		public void DateTimeOffset_AddTo_After_and_op_Addition_are_all_the_same ()
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

		[Test]
		public void Supports_a_TimeSpan_component_for_addition ()
		{
			var twoMonthsTwoDays = new VariableTimeSpan(0, 2, 2.Days());
			Assert.That(2.February(2001) + twoMonthsTwoDays, Is.EqualTo(4.April(2001))); // adding to DateTime
			Assert.That(1.May(2001).At(4).Offset(-4) + twoMonthsTwoDays,                 // adding to DateTimeOffset
			            Is.EqualTo(DateTimeOffset.Parse("2001/07/3 04:00 -4")));
			Assert.That(1.Year(1.Month()) + twoMonthsTwoDays,                            // adding to VariableTimeSpan
			            Is.EqualTo(new VariableTimeSpan(1, 3, 2.Days())));
			Assert.That(3.Days() + twoMonthsTwoDays,                                     // adding to TimeSpan
			            Is.EqualTo(new VariableTimeSpan(0, 2, 5.Days())));
		}

		[Test]
		public void Adds_to_a_TimeSpan_in_both_directions ()
		{
			Assert.That(2.Months() + 2.Days(), Is.EqualTo(2.Days() + 2.Months()));
		}
		
		[Test]
		public void Compares_equality_in_basic_cases ()
		{
			Assert.IsTrue(new VariableTimeSpan(2, 1) == new VariableTimeSpan(2, 1));
			Assert.IsFalse(new VariableTimeSpan(2, 1) != new VariableTimeSpan(2, 1));
			Assert.IsTrue(new VariableTimeSpan(2, 1) != new VariableTimeSpan(2, 2));
			Assert.IsFalse(new VariableTimeSpan(2, 1) == new VariableTimeSpan(2, 2));
			Assert.IsTrue(new VariableTimeSpan(2, 1) != new VariableTimeSpan(1, 1));
			Assert.IsFalse(new VariableTimeSpan(2, 1) == new VariableTimeSpan(1, 1));
			Assert.IsTrue(new VariableTimeSpan(2, 1, 1.Day()) != new VariableTimeSpan(2, 1, 2.Days()));
		}
		
		[Test]
		public void Rolls_12_months_into_a_year_for_equality_comparison ()
		{
			Assert.IsTrue(new VariableTimeSpan(1, 0) == new VariableTimeSpan(0, 12));
			Assert.IsTrue(new VariableTimeSpan(1, 1) == new VariableTimeSpan(0, 13));
			Assert.IsTrue(new VariableTimeSpan(2, 2) == new VariableTimeSpan(1, 14));
		}
		
		[Test]
		public void Generates_reasonable_hash_codes ()
		{
			Assert.IsTrue(new VariableTimeSpan(2, 1).GetHashCode() == new VariableTimeSpan(2, 1).GetHashCode());
			Assert.IsTrue(new VariableTimeSpan(2, 1).GetHashCode() != new VariableTimeSpan(2, 2).GetHashCode());
			Assert.IsTrue(new VariableTimeSpan(2, 1).GetHashCode() != new VariableTimeSpan(1, 1).GetHashCode());
		}
	}
}
