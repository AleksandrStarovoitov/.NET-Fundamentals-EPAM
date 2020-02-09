using ClassLibrary.BL.Interfaces;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.BL.Notifications
{
    public class SmsNotifier : INotifier
    {
        private readonly ILogger<SmsNotifier> logger;

        public SmsNotifier(ILogger<SmsNotifier> logger)
        {
            this.logger = logger;
        }

        public void SendNotification()
        {
            logger?.LogInformation("SMS notification is sent.");
        }
    }
}