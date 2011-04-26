using System;
using NUnit.Framework;

namespace FluentTime.Tests
{
	[TestFixture]
	public class TimeSpanExtensionTest
	{
		[Test]
		public void Creates_a_DateTime_before_the_given_DateTime ()
		{
			Assert.AreEqual(
			                new DateTime(2011, 4, 21, 13, 59, 0),
			                2.Days().Before(new DateTime(2011, 4, 23, 13, 59, 0)));
		}
		[Test]
		public void Creates_a_DateTime_after_the_given_DateTime ()
		{
			Assert.AreEqual(
			                new DateTime(2011, 4, 24, 10, 0, 0), 
			                1.Day().After(new DateTime(2011, 4, 23, 10, 0, 0)));
		}
		
		[Test]
		public void Creates_a_DateTimeOffset_before_the_given_DateTimeOffset_maintaining_the_Offset()
		{
			var expected = DateTimeOffset.Parse("2011/04/26 12:17:00 AM -4:00");
			var actual = 2.Hours().Before(DateTimeOffset.Parse("2011/04/26 2:17:00 AM -4:00"));
			Assert.AreEqual(expected.DateTime, actual.DateTime);
			Assert.AreEqual(expected.Offset, actual.Offset);
		}
		[Test]
		public void Creates_a_DateTimeOffset_after_the_given_DateTimeOffset_maintaining_the_Offset()
		{
			var expected = DateTimeOffset.Parse("2011/04/26 12:17:00 AM -5:00");
			var actual = 3.Hours().After(DateTimeOffset.Parse("2011/04/25 9:17:00 PM -5:00"));
			Assert.AreEqual(expected.DateTime, actual.DateTime);
			Assert.AreEqual(expected.Offset, actual.Offset);
		}
	}
}
