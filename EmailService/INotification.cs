namespace EmailService
{
    interface INotification
    {
        string EventualNotification { get; set; }
        string periodicNotification { get; set; }

        void ErrorLogger(string lines);
        void ProgramLogger(string lines);
        string sendEventualNotification(string notificationText);
        string sendNotification(string notification);
        string sendPeriodicNotification(string notificationText, string configuration, string Time, byte? day = default(byte?));
    }
}