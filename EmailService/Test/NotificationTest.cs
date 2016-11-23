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
            Assert.That(expectedResult, Is.EqualTo("Notification was send it").Or.EqualTo("Notification was not send it"));
        }

        [Test]
        public void ShouldSendPeriodicDailyNotification()
        {
            string expectedResult = testSubject.sendPeriodicNotification("Test", "monthly", "8:18 PM", 22);
            Assert.That(expectedResult, Is.EqualTo("Notification was send it").Or.EqualTo("Notification was not send it"));
        }

        [Test]
        public void ShouldSendPeriodicWeeklyNotification()
        {
            string expectedResult = testSubject.sendPeriodicNotification("Test", "weekly", "8:18 PM", 22);
            Assert.That(expectedResult, Is.EqualTo("Notification was send it").Or.EqualTo("Notification was not send it"));
        }

        [Test]
        public void ShouldSendPeriodicMonthlyNotification()
        {
            string expectedResult = testSubject.sendPeriodicNotification("Test", "dayly", "8:18 PM");
            Assert.That(expectedResult, Is.EqualTo("Notification was send it").Or.EqualTo("Notification was not send it"));
        }

        [Test]
        public void ShouldsendPeriodicNotification()
        {
            var expectedResult = new Mock<INotification>();
            expectedResult.Setup(t => t.sendPeriodicNotification("Test", "monthly", "8:18 PM", 22)).Returns("Notification was send it");
            string test = testSubject.sendPeriodicNotification("Test", "monthly", "8:18 PM", 22);
            expectedResult.Verify(p => p.periodicNotification, test);
        }

        [Test]
        public void shouldWriteOnTheProgramFile()
        {
            var expectedResult = new Mock<INotification>();
            expectedResult.Setup(test => test.sendPeriodicNotification(It.IsAny<string>(), "monthly", "8:18 PM", 22)).Returns("Notification was send it");
            testSubject.sendNotification("Test");
        }

        [Test]
        public void shouldSendNotificationOrFail()
        {
            string expectedResult = testSubject.sendNotification("Test");
            Assert.That((testSubject.sendNotification("Test") == "Notification was send it" || testSubject.sendNotification("Test") == "Notification was not send it") ? true : false, "Failed");
        }

        [Test]
        public void writtingOnNotificationFile()
        {
            testSubject.ProgramLogger("Example of text");

            int counter = 0;
            string line;
            bool exist = false;
            var text = "Example of text";
            System.IO.StreamReader file = new System.IO.StreamReader("NotificationControl.txt");

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(text))
                {
                    exist = true;
                }
                counter++;
            }
            file.Close();

            Assert.True(exist);
        }

        [Test]
        public void writtingOnErrorFile()
        {
            testSubject.ProgramLogger("Example of text");

            int counter = 0;
            string line;
            bool exist;
            var text = "Example of text";
            System.IO.StreamReader file = new System.IO.StreamReader("ErrorControl.txt");

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(text))
                {
                    exist = true;
                }
                counter++;
            }
            file.Close();

            exist = false;

            Assert.True(exist);
        }

        [Test]
        public void shouldWriteOnTheNotificationFileOrFailAndWriteOnTheErrorFile()
        {
            var expectedResult = new Mock<INotification>();
            expectedResult.Setup(test => test.sendPeriodicNotification(It.IsAny<string>(), "monthly", "8:18 PM", 22)).Returns("Notification was send it");

            int counter = 0;
            bool exist = false;
            var text = "Prueba para fallo o exito";

            System.IO.StreamReader success = new System.IO.StreamReader("NotificationControl.txt");
            System.IO.StreamReader error = new System.IO.StreamReader("ErrorControl.txt");

            string successLine = success.ReadLine();
            string errorLine = success.ReadLine();

            while ((successLine != null || errorLine != null))
            {
                if (successLine.Contains(text) || errorLine.Contains(text))
                {
                    exist = true;
                }
                counter++;
            }
            success.Close();
            error.Close();

            Assert.True(exist);
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            testSubject = null;
        }




    }
}
