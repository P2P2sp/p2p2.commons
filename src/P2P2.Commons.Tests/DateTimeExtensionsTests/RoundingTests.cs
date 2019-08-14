using NUnit.Framework;
using System;

namespace P2P2.Commons.Tests.DateTimeExtensionsTests
{
    [TestFixture]
    public class RoundingTests
    {
        //[Test]
        //[TestCase("2018-07-10 12:44:58", "2018-07-10 12:45:00", 15)]
        //[TestCase("2018-07-10 12:45:01", "2018-07-10 12:50:00", 5)]
        //[TestCase("2018-07-10 13:10:00", "2018-07-10 13:10:00", 10)]
        //[TestCase("2018-07-10 16:15:00", "2018-07-10 16:45:00", 30)] // nie przechodzi
        //public void RoundingUp_ReturnsRoundedValue(DateTime dateTime, DateTime expected, int rounding)
        //{
        //    var sut = dateTime.RoundUp(TimeSpan.FromMinutes(rounding));
        //    Assert.AreEqual(expected, sut);
        //}

        //[Test]
        //[TestCase("2018-07-10 12:44:58", "2018-07-10 12:30:00", 15)]
        //[TestCase("2018-07-10 12:45:01", "2018-07-10 12:45:00", 5)]
        //[TestCase("2018-07-10 13:10:00", "2018-07-10 13:10:00", 10)]
        //[TestCase("2018-07-10 16:45:00", "2018-07-10 16:15:00", 30)] // nie przechodzi
        //public void RoundingDown_ReturnsRoundedValue(DateTime dateTime, DateTime expected, int rounding)
        //{
        //    var sut = dateTime.RoundDown(TimeSpan.FromMinutes(rounding));
        //    Assert.AreEqual(expected, sut);
        //}
    }
}