using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EmailService.Test
{
    [TestFixture]
    class NotificationTest
    {
        Notification testSubject;
        [OneTimeSetUp]
        public void TestSetup()
        {
            testSubject = new Notification();
        }

        [Test]
        public void ShouldCreatePeriodicNotificationOnEmpty()
        {
            string expectedResult = testSubject.periodicNotification;
            Assert.That(expectedResult, Is.EqualTo(""));
        }

        [Test]
        public void ShouldCreateEventualNotificationOnEmpty()
        {
            string expectedResult = testSubject.eventualNotification;
            Assert.That(expectedResult, Is.EqualTo(""));
        }

        [Test]
        public void ShouldSendEventualNotification()
        {
            string expectedResult = testSubject.sendEventualNotification("Test Notification");
            Assert.That(expectedResult, Is.EqualTo("Notification was send it"));
        }

        [Test]
        public void ShouldSendPeriodicDailyNotification()
        {
            string expectedResult = testSubject.sendPeriodicNotification("Test", "Monthly", "3:50");
            Assert.That(expectedResult, Is.EqualTo("Notification was send it"));
        }

        [Test]
        public void ShouldSendPeriodicWeeklyNotification()
        {
            string expectedResult = testSubject.sendPeriodicNotification("Test", "Weekly", "23 3:50");
            Assert.That(expectedResult, Is.EqualTo("Notification was send it"));
        }

        [Test]
        public void ShouldSendPeriodicMonthlyNotification()
        {
            string expectedResult = testSubject.sendPeriodicNotification("Test", "Monthly", "23 3:50");
            Assert.That(expectedResult, Is.EqualTo("Notification was send it"));
        }

    }
}
