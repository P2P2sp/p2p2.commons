using NUnit.Framework;

namespace TH.Commons.Tests.StringExpansionsTests
{
    [TestFixture]
    public class TrimWithSuffixTests
    {
        [Test]
        public void ValueLongerThanMax_TrimWithSuffix_LengthWithSuffixNoLongerThanMax()
        {
            const string value = "test56789";
            const int maxLength = 8;
            const string suffix = "...";
            var result = value.Trim(maxLength, suffix);
            Assert.AreEqual("test5...", result);
            Assert.IsTrue(result.Length <= maxLength);
        }

        [Test]
        public void ValueShorterThanMax_NoTrim()
        {
            const string value = "test";
            const int maxLength = 8;
            const string suffix = "...";
            var result = value.Trim(maxLength, suffix);
            Assert.AreEqual("test", result);
            Assert.IsTrue(result.Length <= maxLength);
        }

        [Test]
        public void ValueShorterThanMax_ButWithSuffixIsLonger_NoTrim()
        {
            const string value = "test567";
            const int maxLength = 8;
            const string suffix = "...";
            var result = value.Trim(maxLength, suffix);
            Assert.AreEqual("test567", result);
            Assert.IsTrue(result.Length <= maxLength);
        }
    }
}
