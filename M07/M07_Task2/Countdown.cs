using System;

namespace M07_Task2
{
    internal class Countdown
    {
        public event EventHandler SendMessage;

        protected virtual void OnSendMessage()
        {
            SendMessage?.Invoke(this, null);
        }

        public void SendMessages()
        {
            OnSendMessage();
        }
    }
}
