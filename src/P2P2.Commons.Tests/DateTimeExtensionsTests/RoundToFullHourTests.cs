using NUnit.Framework;
using System;

namespace P2P2.Commons.Tests.DateTimeExtensionsTests
{
    [TestFixture]
    public class RoundToFullHourTests
    {
        private const int maxMinutesGap15 = 15;

        [Test]
        public void RoundingUp_UnderMaxMinutesGap_ReturnsOriginalValue()
        {
            var dateTime = new DateTime(2018, 07, 10, 12, 44, 58);
            var expected = dateTime;
            var sut = dateTime.RoundToFullHour(maxMinutesGap15);
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void RoundingUp_OverMaxMinutesGap_ReturnsValueRoundedUp()
        {
            var dateTime = new DateTime(2018, 07, 10, 12, 45, 01);
            var expected = new DateTime(2018, 07, 10, 13, 00, 00);
            var sut = dateTime.RoundToFullHour(maxMinutesGap15);
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void RoundingDown_OverMaxMinutesGap_ReturnsOriginalValue()
        {
            var dateTime = new DateTime(2018, 07, 10, 12, 16, 00);
            var expected = dateTime;
            var sut = dateTime.RoundToFullHour(maxMinutesGap15);
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void RoundingDown_UnderMaxMinutesGap_ReturnsValueRoundedDown()
        {
            var dateTime = new DateTime(2018, 07, 10, 12, 15, 59);
            var expected = new DateTime(2018, 07, 10, 12, 00, 00);
            var sut = dateTime.RoundToFullHour(maxMinutesGap15);
            Assert.AreEqual(expected, sut);
        }
    }
}