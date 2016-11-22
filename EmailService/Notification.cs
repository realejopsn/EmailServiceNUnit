using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace EmailService
{
    class Notification
    {
        string source;
        string log;
        string eventLog;
        private String _periodicNotification;
        private String _eventualNotification;

        public Notification()
        {
            _periodicNotification = "";
            _eventualNotification = "";            
        }

        public String periodicNotification { get { return _periodicNotification; } set { _periodicNotification = value; } }
        public String eventualNotification { get { return _eventualNotification; } set { _eventualNotification = value; } }

        public string sendPeriodicNotification(String notificationText, String configuration, String Time)
        {              
                
            if (configuration.ToLower() == "daily")
            {
                return sendDailyNotification(notificationText, configuration, Time);
                
            }
            else if (configuration.ToLower() == "weekly")
            {
                return sendWeeklyNotification(notificationText, configuration, Time);
               
            }
            else if (configuration.ToLower() == "monthly")
            {
                return sendMonthlyNotification(notificationText, configuration, Time);                
            }
            else
            {
                throw new System.ArgumentException("Configuration does not exist: ", configuration);
            }
        }

        private string sendMonthlyNotification(String notificationText, String configuration, String Time)
        {
            DateTime localDate = DateTime.Now;
            string logText = notificationText + Time;
            Logger(logText);



            return sendNotification(notificationText);
        }
        

        private string sendWeeklyNotification(String notificationText, String configuration, String Time)
        {
            DateTime localDate = DateTime.Now;
            
            source = "Perodic Notification on: " + configuration.ToLower() + "on date: " + localDate;
            eventLog = Time;
            EventLog.WriteEntry(source, eventLog);
            return sendNotification(notificationText);
        }

        private string sendDailyNotification(String notificationText, String configuration, String Time)
        {
            DateTime localDate = DateTime.Now;
            
            source = "Perodic Notification on: " + configuration.ToLower() + "on date: " + localDate;
            eventLog = Time;
            EventLog.WriteEntry(source, eventLog);
            return sendNotification(notificationText);
        }

        public string sendEventualNotification(String notificationText)
        {
            _eventualNotification = notificationText;
            return sendNotification(_eventualNotification);
        }

        public String sendNotification(String notification)
        {
            return "Notification was send it";
        }

        public void Logger(String lines)
        {            
            string location = Directory.GetCurrentDirectory();
            System.IO.StreamWriter file = new System.IO.StreamWriter(location + "NotificationControl.txt", true);
            file.WriteLine(lines);

            file.Close();

        }

    }





}

