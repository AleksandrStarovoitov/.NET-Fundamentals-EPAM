using ClassLibrary.BL.Interfaces;
using NLog;

namespace ClassLibrary.BL.Notifications
{
    public class EmailNotifier : INotifier
    {
        private readonly ILogger logger;

        public EmailNotifier(ILogger logger)
        {
            this.logger = logger;
        }

        public void SendNotification()
        {
            logger.Info("Email notification is sent.");
        }
    }
}