using ClassLibrary.BL.Interfaces;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.BL.Notifications
{
    public class EmailNotifier : INotifier
    {
        private readonly ILogger<EmailNotifier> logger;

        public EmailNotifier(ILogger<EmailNotifier> logger)
        {
            this.logger = logger;
        }

        public void SendNotification()
        {
            logger.LogInformation("Email notification is sent.");
        }
    }
}