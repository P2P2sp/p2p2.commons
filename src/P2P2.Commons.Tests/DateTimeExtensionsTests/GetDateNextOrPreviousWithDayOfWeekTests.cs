using System;
using NUnit.Framework;

namespace P2P2.Commons.Tests.DateTimeExtensionsTests
{
    [TestFixture]
    public class GetDateNextOrPreviousWithDayOfWeekTests
    {
        private static readonly DateTime monday = new DateTime(2017, 10, 30);
        private static readonly DateTime thursday = new DateTime(2017, 11, 2);
        private static readonly DateTime sunday = new DateTime(2017, 11, 5);

        [Test]
        public void CheckStaticFields()
        {
            Assert.AreEqual(DayOfWeek.Monday, monday.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Thursday, thursday.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Sunday, sunday.DayOfWeek);
        }

        [Test]
        public void MondayToWednesdayTest()
        {
            var nextWednesday = monday.GetDateNext(DayOfWeek.Wednesday);
            Assert.AreEqual(monday.AddDays(2), nextWednesday);
            nextWednesday = monday.GetDateNextOrCurrent(DayOfWeek.Wednesday);
            Assert.AreEqual(monday.AddDays(2), nextWednesday);
            var prevWednesday = monday.GetDatePrevious(DayOfWeek.Wednesday);
            Assert.AreEqual(monday.AddDays(-5), prevWednesday);
            prevWednesday = monday.GetDatePreviousOrCurrent(DayOfWeek.Wednesday);
            Assert.AreEqual(monday.AddDays(-5), prevWednesday);
        }

        [Test]
        public void MondayToSundayTest()
        {
            var nextSunday = monday.GetDateNext(DayOfWeek.Sunday);
            Assert.AreEqual(monday.AddDays(6), nextSunday);
            nextSunday = monday.GetDateNextOrCurrent(DayOfWeek.Sunday);
            Assert.AreEqual(monday.AddDays(6), nextSunday);
            var prevSunday = monday.GetDatePrevious(DayOfWeek.Sunday);
            Assert.AreEqual(monday.AddDays(-1), prevSunday);
            prevSunday = monday.GetDatePreviousOrCurrent(DayOfWeek.Sunday);
            Assert.AreEqual(monday.AddDays(-1), prevSunday);
        }

        [Test]
        public void MondayToMondayTest()
        {
            var nextMonday = monday.GetDateNext(DayOfWeek.Monday);
            Assert.AreEqual(monday.AddDays(7), nextMonday);
            nextMonday = monday.GetDateNextOrCurrent(DayOfWeek.Monday);
            Assert.AreEqual(monday, nextMonday);
            var prevMonday = monday.GetDatePrevious(DayOfWeek.Monday);
            Assert.AreEqual(monday.AddDays(-7), prevMonday);
            prevMonday = monday.GetDatePreviousOrCurrent(DayOfWeek.Monday);
            Assert.AreEqual(monday, prevMonday);
        }


        [Test]
        public void SundayToWednesdayTest()
        {
            var nextWednesday = sunday.GetDateNext(DayOfWeek.Wednesday);
            Assert.AreEqual(sunday.AddDays(3), nextWednesday);
            nextWednesday = sunday.GetDateNextOrCurrent(DayOfWeek.Wednesday);
            Assert.AreEqual(sunday.AddDays(3), nextWednesday);
            var prevWednesday = sunday.GetDatePrevious(DayOfWeek.Wednesday);
            Assert.AreEqual(sunday.AddDays(-4), prevWednesday);
            prevWednesday = sunday.GetDatePreviousOrCurrent(DayOfWeek.Wednesday);
            Assert.AreEqual(sunday.AddDays(-4), prevWednesday);
        }

        [Test]
        public void SundayToSundayTest()
        {
            var nextSunday = sunday.GetDateNext(DayOfWeek.Sunday);
            Assert.AreEqual(sunday.AddDays(7), nextSunday);
            nextSunday = sunday.GetDateNextOrCurrent(DayOfWeek.Sunday);
            Assert.AreEqual(sunday, nextSunday);
            var prevSunday = sunday.GetDatePrevious(DayOfWeek.Sunday);
            Assert.AreEqual(sunday.AddDays(-7), prevSunday);
            prevSunday = sunday.GetDatePreviousOrCurrent(DayOfWeek.Sunday);
            Assert.AreEqual(sunday, prevSunday);
        }

        [Test]
        public void SundayToMondayTest()
        {
            var nextMonday = sunday.GetDateNext(DayOfWeek.Monday);
            Assert.AreEqual(sunday.AddDays(1), nextMonday);
            nextMonday = sunday.GetDateNextOrCurrent(DayOfWeek.Monday);
            Assert.AreEqual(sunday.AddDays(1), nextMonday);
            var prevMonday = sunday.GetDatePrevious(DayOfWeek.Monday);
            Assert.AreEqual(sunday.AddDays(-6), prevMonday);
            prevMonday = sunday.GetDatePreviousOrCurrent(DayOfWeek.Monday);
            Assert.AreEqual(sunday.AddDays(-6), prevMonday);
        }


        [Test]
        public void ThursdayToSundayTest()
        {
            var nextSunday = thursday.GetDateNext(DayOfWeek.Sunday);
            Assert.AreEqual(thursday.AddDays(3), nextSunday);
            nextSunday = thursday.GetDateNextOrCurrent(DayOfWeek.Sunday);
            Assert.AreEqual(thursday.AddDays(3), nextSunday);
            var prevSunday = thursday.GetDatePrevious(DayOfWeek.Sunday);
            Assert.AreEqual(thursday.AddDays(-4), prevSunday);
            prevSunday = thursday.GetDatePreviousOrCurrent(DayOfWeek.Sunday);
            Assert.AreEqual(thursday.AddDays(-4), prevSunday);
        }

        [Test]
        public void ThursdayToMondayTest()
        {
            var nextMonday = thursday.GetDateNext(DayOfWeek.Monday);
            Assert.AreEqual(thursday.AddDays(4), nextMonday);
            nextMonday = thursday.GetDateNextOrCurrent(DayOfWeek.Monday);
            Assert.AreEqual(thursday.AddDays(4), nextMonday);
            var prevMonday = thursday.GetDatePrevious(DayOfWeek.Monday);
            Assert.AreEqual(thursday.AddDays(-3), prevMonday);
            prevMonday = thursday.GetDatePreviousOrCurrent(DayOfWeek.Monday);
            Assert.AreEqual(thursday.AddDays(-3), prevMonday);
        }

        [Test]
        public void ThursdayToSaturdayTest()
        {
            var nextMonday = thursday.GetDateNext(DayOfWeek.Saturday);
            Assert.AreEqual(thursday.AddDays(2), nextMonday);
            nextMonday = thursday.GetDateNextOrCurrent(DayOfWeek.Saturday);
            Assert.AreEqual(thursday.AddDays(2), nextMonday);
            var prevMonday = thursday.GetDatePrevious(DayOfWeek.Saturday);
            Assert.AreEqual(thursday.AddDays(-5), prevMonday);
            prevMonday = thursday.GetDatePreviousOrCurrent(DayOfWeek.Saturday);
            Assert.AreEqual(thursday.AddDays(-5), prevMonday);
        }

        [Test]
        public void ThursdayToWednesdayTest()
        {
            var nextMonday = thursday.GetDateNext(DayOfWeek.Wednesday);
            Assert.AreEqual(thursday.AddDays(6), nextMonday);
            nextMonday = thursday.GetDateNextOrCurrent(DayOfWeek.Wednesday);
            Assert.AreEqual(thursday.AddDays(6), nextMonday);
            var prevMonday = thursday.GetDatePrevious(DayOfWeek.Wednesday);
            Assert.AreEqual(thursday.AddDays(-1), prevMonday);
            prevMonday = thursday.GetDatePreviousOrCurrent(DayOfWeek.Wednesday);
            Assert.AreEqual(thursday.AddDays(-1), prevMonday);
        }
    }
}