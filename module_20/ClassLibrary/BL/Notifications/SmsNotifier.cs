using ClassLibrary.BL.Interfaces.Notifications;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.BL.Notifications
{
    public class SmsNotifier : ISmsNotifier
    {
        private readonly ILogger<SmsNotifier> logger;

        public SmsNotifier(ILogger<SmsNotifier> logger)
        {
            this.logger = logger;
        }

        public void SendNotification(string notification)
        {
            logger?.LogInformation(notification);
        }
    }
}