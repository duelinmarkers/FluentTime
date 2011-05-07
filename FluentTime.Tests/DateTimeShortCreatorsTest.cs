using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace FluentTime.Tests
{
	[TestFixture]
	public class DateTimeShortCreatorsTest
	{
        [SetUp]
        public void Setup()
        {
            AdjustableCurrentTime.SetNow(8.May(2011));
        }

	    [TearDown]
        public void TearDown()
        {
            AdjustableCurrentTime.Reset();
        }

        [Test]
        public void Today_Time_can_be_specified_with_At()
        {
            Assert.That(Today.At(14), Is.EqualTo(8.May(2011).At(14)));
            Assert.That(Today.At(14, 30), Is.EqualTo(8.May(2011).At(14, 30)));
            Assert.That(Today.At(14, 30, 26), Is.EqualTo(8.May(2011).At(14, 30, 26)));
        }

        [Test]
        public void Tomorrow_Time_can_be_specified_with_At()
        {
            Assert.That(Tomorrow.At(14), Is.EqualTo(9.May(2011).At(14)));
            Assert.That(Tomorrow.At(14, 30), Is.EqualTo(9.May(2011).At(14, 30)));
            Assert.That(Tomorrow.At(14, 30, 26), Is.EqualTo(9.May(2011).At(14, 30, 26)));
        }

        [Test]
        public void Yesterday_Time_can_be_specified_with_At()
        {
            Assert.That(Yesterday.At(14), Is.EqualTo(7.May(2011).At(14)));
            Assert.That(Yesterday.At(14, 30), Is.EqualTo(7.May(2011).At(14, 30)));
            Assert.That(Yesterday.At(14, 30, 26), Is.EqualTo(7.May(2011).At(14, 30, 26)));
        }


	    [Test]
		public void Next_can_create_for_all_weekdays()
        {
	        Assert.That(Next.Monday(),    Is.EqualTo(9.May(2011)));
            Assert.That(Next.Tuesday(),   Is.EqualTo(10.May(2011)));
            Assert.That(Next.Wednesday(), Is.EqualTo(11.May(2011)));
            Assert.That(Next.Thursday(),  Is.EqualTo(12.May(2011)));
            Assert.That(Next.Friday(),    Is.EqualTo(13.May(2011)));
            Assert.That(Next.Saturday(),  Is.EqualTo(14.May(2011)));
            Assert.That(Next.Sunday(),    Is.EqualTo(15.May(2011)));
        }

        [Test]
        public void Last_can_create_for_all_weekdays()
        {
            Assert.That(Last.Monday(), Is.EqualTo(2.May(2011)));
            Assert.That(Last.Tuesday(), Is.EqualTo(3.May(2011)));
            Assert.That(Last.Wednesday(), Is.EqualTo(4.May(2011)));
            Assert.That(Last.Thursday(), Is.EqualTo(5.May(2011)));
            Assert.That(Last.Friday(), Is.EqualTo(6.May(2011)));
            Assert.That(Last.Saturday(), Is.EqualTo(7.May(2011)));
            Assert.That(Last.Sunday(), Is.EqualTo(1.May(2011)));
        }
	}
}
