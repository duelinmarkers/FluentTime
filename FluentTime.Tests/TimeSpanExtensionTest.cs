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
	}
}
