using System;
using System.Threading;

namespace M07_Task2
{
    abstract class TestSubscriber
    {
        private double waitSeconds;

        public void Subscribe(Countdown cd, double waitSeconds)
        {
            if (cd == null)
            {
                throw new ArgumentNullException(nameof(cd));
            }

            if (waitSeconds < 0)
            {
                throw new ArgumentException("You can't wait for negative number of seconds.", nameof(waitSeconds));
            }

            cd.SendMessage += Cd_SendMessage;
            this.waitSeconds = waitSeconds;
        }

        public void Unsubscribe(Countdown cd)
        {
            if (cd == null)
            {
                throw new ArgumentNullException(nameof(cd));
            }

            cd.SendMessage -= Cd_SendMessage;
        }

        private void Cd_SendMessage(object sender, EventArgs e)
        {
            var typeName = this.GetType().Name;

            Console.WriteLine($"{typeName}. Waiting for {waitSeconds} seconds...");
            Thread.Sleep(TimeSpan.FromSeconds(waitSeconds));
            Console.WriteLine($"{typeName}. Finished waiting.");
        }
    }
}
