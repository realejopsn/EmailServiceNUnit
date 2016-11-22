using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

        public void sendPeriodicNotification(String notificationText, String configuration, String Time)
        {
            DateTime localDate = DateTime.Now;
            if (!EventLog.SourceExists(source))
            {
                log     = "Application";
                source  = "Perodic Notification Control";
                EventLog.CreateEventSource(source, log);
            }
                
            if (configuration.ToLower() == "daily")
            {
                source      = "Perodic Notification on: " + configuration.ToLower() + "on date: " + localDate;
                eventLog    = Time;
                EventLog.WriteEntry(source, eventLog);
            }
            else if (configuration.ToLower() == "weekly")
            {
                source      = "Perodic Notification on: " + configuration.ToLower() + "on date: " + localDate;
                eventLog    = Time;
                EventLog.WriteEntry(source, eventLog);
            }
            else if (configuration.ToLower() == "monthly")
            {
                source      = "Perodic Notification on: " + configuration.ToLower() + "on date: " + localDate;
                eventLog    = Time;
                EventLog.WriteEntry(source, eventLog);
            }
            else
            {
                throw new System.ArgumentException("Configuration does not exist: ", configuration);
            }
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

    }



}

