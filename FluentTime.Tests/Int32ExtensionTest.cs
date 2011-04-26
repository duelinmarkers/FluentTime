using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace FluentTime.Tests
{
	[TestFixture]
	public class Int32ExtensionTest
	{
		[Test]
		public void Creates_TimeSpans_readably ()
		{
			Assert.That(2.Days(), Is.EqualTo(TimeSpan.FromDays(2)));
			Assert.That(2.Hours(), Is.EqualTo(TimeSpan.FromHours(2)));
			Assert.That(2.Minutes(), Is.EqualTo(TimeSpan.FromMinutes(2)));
			Assert.That(2.Seconds(), Is.EqualTo(TimeSpan.FromSeconds(2)));
			Assert.That(2.Milliseconds(), Is.EqualTo(TimeSpan.FromMilliseconds(2)));
			Assert.That(2.Ticks(), Is.EqualTo(TimeSpan.FromTicks(2)));
		}
		
		[Test]
		public void Supports_singular_aliases ()
		{
			Assert.That(1.Day(), Is.EqualTo(TimeSpan.FromDays(1)));
			Assert.That(1.Hour(), Is.EqualTo(TimeSpan.FromHours(1)));
			Assert.That(1.Minute(), Is.EqualTo(TimeSpan.FromMinutes(1)));
			Assert.That(1.Second(), Is.EqualTo(TimeSpan.FromSeconds(1)));
			Assert.That(1.Millisecond(), Is.EqualTo(TimeSpan.FromMilliseconds(1)));
			Assert.That(1.Tick(), Is.EqualTo(TimeSpan.FromTicks(1)));
		}
	}
}
