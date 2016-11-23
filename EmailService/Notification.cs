using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmailService
{
    class Notification : INotification
    {
        private String _eventualNotification;
        private String _peridicalNotification;

        public Notification()
        {
            _eventualNotification = "";
            _peridicalNotification = "";

        }

        public String EventualNotification { get { return _eventualNotification; } set { _eventualNotification = value; } }
        public String periodicNotification { get { return _peridicalNotification; } set { _peridicalNotification = value; } }

        public string sendEventualNotification(String notificationText)
        {            
            _eventualNotification = notificationText;

            return "Notification was send it";
        }

        public string sendPeriodicNotification(String notificationText, String configuration, String Time, Nullable<Byte> day = null)
        {              
                
            if (configuration.ToLower() == "daily")
            {
                return sendDailyNotification(notificationText, configuration, Time);
                
            }
            else if (configuration.ToLower() == "weekly")
            {
                return sendWeeklyNotification(notificationText, configuration, (Byte)day, Time);
               
            }
            else if (configuration.ToLower() == "monthly")
            {
                return sendMonthlyNotification(notificationText, configuration, (Byte)day, Time);                
            }
            else
            {
                throw new System.ArgumentException("Configuration does not exist: ", configuration);
            }
        }

        private string sendMonthlyNotification(String notificationText, String configuration, Byte day, String Time)
        {
            DateTime localDate = DateTime.Now;
            String localTime = localDate.ToShortTimeString();
            if (localDate.Day == day && localTime == Time)
            {
                string logText = "Monthly Notification: " + notificationText + ", at: " + day + ' ' + Time;
                ProgramLogger(logText);
                return sendNotification(notificationText);
            }

            else
            {
                ErrorLogger(notificationText);
                return "Notification was not send it";
            }
        }
        

        private string sendWeeklyNotification(String notificationText, String configuration, Byte day, String Time)
        {
            DateTime localDate = DateTime.Now;
            String localTime = localDate.ToShortTimeString();
            if (localDate.Day == day && localTime == Time)
            {
                string logText = "Weekly Notification: " + notificationText + ", at: " + day + ' ' + Time;
                ProgramLogger(logText);
                return sendNotification(notificationText);
            }

            else
            {
                ErrorLogger(notificationText);
                return "Notification was not send it";
            }
        }

        private string sendDailyNotification(String notificationText, String configuration, String Time)
        {
            DateTime localDate = DateTime.Now;
            String localTime = localDate.ToShortTimeString();
            if(localTime == Time)
            {
                string logText = "Daily Notification: " + notificationText + ", at: " + Time;
                ProgramLogger(logText);
                return sendNotification(notificationText);
            }
            else
            {
                ErrorLogger(notificationText);
                return "Notification was not send it";
            }

            
        }

        public String sendNotification(String notification)
        {            
            Random random = new Random();
            int ran = random.Next(0, 1);
            bool notificationWasSendIt = ran == 1 ? true : false;
            if (notificationWasSendIt)
            {
                return "Notification was send it";
            }
            else
            {
                ErrorLogger(notification);
                return "Notification was not send it";
            }                   
        }

        public void ProgramLogger(String lines)
        {            
            string location = Directory.GetCurrentDirectory();
            System.IO.StreamWriter file = new System.IO.StreamWriter(location + "NotificationControl.txt", true);
            file.WriteLine(lines);

            file.Close();
        }

        public void ErrorLogger(String lines)
        {
            string location = Directory.GetCurrentDirectory();
            System.IO.StreamWriter file = new System.IO.StreamWriter(location + "ErrorControl.txt", true);
            file.WriteLine(lines);

            file.Close();
        }

    }





}

