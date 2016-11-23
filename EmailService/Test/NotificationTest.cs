using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Moq.Properties;
using Rhino.Mocks;

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
        public void ShouldCreateNotificationTextOnEmpty()
        {
            string expectedResult = testSubject.EventualNotification;
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
            string expectedResult = testSubject.sendPeriodicNotification("Test", "monthly", "8:18 PM", 22);
            Assert.That(expectedResult, Is.EqualTo("Notification was send it"));
        }

        [Test]
        public void ShouldSendPeriodicWeeklyNotification()
        {
            string expectedResult = testSubject.sendPeriodicNotification("Test", "weekly", "8:18 PM", 22);
            Assert.That(expectedResult, Is.EqualTo("Notification was send it"));
        }

        [Test]
        public void ShouldSendPeriodicMonthlyNotification()
        {
            string expectedResult = testSubject.sendPeriodicNotification("Test", "dayly", "8:18 PM");
            Assert.That(expectedResult, Is.EqualTo("Notification was send it"));
        }

        [Test]
        public void ShouldsendPeriodicNotification()
        {
            var expectedResult = new Mock<Notification>();
            expectedResult.Setup(t => t.periodicNotification).Returns("Notification was send it");
            string test = testSubject.sendPeriodicNotification("Test", "monthly", "8:18 PM", 22);
            expectedResult.Verify(p => test);
        }

        [Test]
        public void shouldWriteOnTheProgramFile()
        {
            var expectedResult = new Mock<Notification>();
            expectedResult.Setup(test => test.sendPeriodicNotification("Test", "monthly", "8:18 PM", 22)).Returns("Notification was send it");
            testSubject.sendNotification("Test");
        }

        [Test]
        public void shouldSendNotificationOrFail()
        {
            string expectedResult = testSubject.sendNotification("Test");
            Assert.That((testSubject.sendNotification("Test") == "Notification was send it" || testSubject.sendNotification("Test") == "Notification was not send it") ? true : false, "Failed");
        }

        [Test]

    }
}
