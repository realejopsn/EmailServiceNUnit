using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EmailService.Test
{
    [TestFixture]
    class EmailTest
    {
        Email testSubject;
        [OneTimeSetUp]
        public void TestSetup()
        {
            testSubject = new Email();
            
        }
    }
}
