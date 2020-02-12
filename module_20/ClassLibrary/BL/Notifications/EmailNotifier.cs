using ClassLibrary.BL.Interfaces.Notifications;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.BL.Notifications
{
    public class EmailNotifier : IEmailNotifier
    {
        private readonly ILogger<EmailNotifier> logger;

        public EmailNotifier(ILogger<EmailNotifier> logger)
        {
            this.logger = logger;
        }

        public void SendNotification(string notification)
        {
            logger?.LogInformation(notification);
        }
    }
}