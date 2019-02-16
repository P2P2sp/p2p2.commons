using NUnit.Framework;

namespace P2P2.Commons.Tests.StringExpansionsTests
{
    [TestFixture]
    public class IsEmailAddressTests
    {
        [TestCase(@"NotAnEmail", false)]
        [TestCase(@"@NotAnEmail", false)]
        [TestCase(@"""test\\blah""@example.com", true)]
        [TestCase(@"""test\blah""@example.com", false)]
        [TestCase("\"test\\\rblah\"@example.com", true)]
        [TestCase("\"test\rblah\"@example.com", false)]
        [TestCase(@"""test\""blah""@example.com", true)]
        [TestCase(@"""test""blah""@example.com", false)]
        [TestCase(@"customer/department@example.com", true)]
        [TestCase(@"$A12345@example.com", true)]
        [TestCase(@"!def!xyz%abc@example.com", true)]
        [TestCase(@"_Yosemite.Sam@example.com", true)]
        [TestCase(@"~@example.com", true)]
        [TestCase(@".wooly@example.com", false)]
        [TestCase(@"wo..oly@example.com", false)]
        [TestCase(@"pootietang.@example.com", false)]
        [TestCase(@".@example.com", false)]
        [TestCase(@"""Austin@Powers""@example.com", true)]
        [TestCase(@"Ima.Fool@example.com", true)]
        [TestCase(@"""Ima.Fool""@example.com", true)]
        [TestCase(@"""Ima Fool""@example.com", true)]
        [TestCase(@"Ima Fool@example.com", false)]
        [Test]
        public void EmailTests(string email, bool expected)
        {
            Assert.AreEqual(expected, email.IsEmailAddress(), "Problem with '" + email + "'. Expected " + expected + " but was not that.");
        }
    }
}
