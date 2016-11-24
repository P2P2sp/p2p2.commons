using System;
using NUnit.Framework;

namespace TH.Commons.Tests.TimeSpanExtensionsTests
{
    [TestFixture]
    public class ToReadableStringTests
    {
        [Test]
        public void More_than_24_hours()
        {
            var date = new TimeSpan(1, 2, 30, 20);
            var result = date.ToReadableString();
            Assert.AreEqual(result, "1d. 2g 30min 20s");
        }

        [Test]
        public void More_than_2_hours()
        {
            var date = new TimeSpan(2, 30, 0);
            var result = date.ToReadableString();
            Assert.AreEqual(result, "2g 30min");
        }
    }
}
