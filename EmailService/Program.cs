using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmailService
{
    class Program
    {
    
        static void Main(string[] args)
        {
            Notification NewNotification = new Notification();
            Byte cont = 1;

            //Console.WriteLine(NewNotification.sendEventualNotification("This is a test"));
            Console.WriteLine("sending message " + "\n");
            String message = NewNotification.sendPeriodicNotification("Test", "monthly", "8:17 PM", 22);
            while (message != "Notification was send it" && cont < 4)
            {
                message = NewNotification.sendPeriodicNotification("Test", "monthly", "8:18 PM", 22);
                cont++;
                Console.Write("..." );
                Thread.Sleep(15000);
            }
            Console.WriteLine("\n");
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
