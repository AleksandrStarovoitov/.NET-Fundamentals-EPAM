using ClassLibrary.BL.Interfaces;
using NLog;

namespace ClassLibrary.BL.Notifications
{
    public class SmsNotifier : INotifier
    {
        private readonly ILogger logger;

        public SmsNotifier(ILogger logger)
        {
            this.logger = logger;
        }

        public void SendNotification()
        {
            logger.Info("SMS notification is sent.");
        }
    }
}