using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace FluentTime.Tests
{
	[TestFixture]
	public class DateTimeCreationTest
	{
		[Test]
		public void Creates_dates_readably ()
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
		public void Created_dates_have_Kind_Unspecified_by_default ()
		{
			Assert.That(5.January(2011).Kind, Is.EqualTo(DateTimeKind.Unspecified));
		}
		
		[Test]
		public void DateTimeKind_can_be_specified ()
		{
			Assert.That(5.January(2011).Utc(),   Is.EqualTo(new DateTime(2011, 1, 5, 0, 0, 0, DateTimeKind.Utc)));
			Assert.That(5.January(2011).Local(), Is.EqualTo(new DateTime(2011, 1, 5, 0, 0, 0, DateTimeKind.Local)));
		}
	}
}
