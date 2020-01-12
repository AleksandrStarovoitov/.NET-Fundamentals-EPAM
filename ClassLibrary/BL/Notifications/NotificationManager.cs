namespace ClassLibrary.BL.Notifications
{
    public class NotificationManager
    {
        private INotifier notifier;

        public NotificationManager(INotifier notifier)
        {
            this.notifier = notifier;
        }

        public void Notify()
        {
            notifier.SendNotification();
        }
    }
}