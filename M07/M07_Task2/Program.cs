namespace M07_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Countdown cd = new Countdown();

            var sub1 = new TestSubscriber1();
            var sub2 = new TestSubscriber2();

            sub1.Subscribe(cd, 4);
            sub2.Subscribe(cd, 2);

            cd.SendMessages();
        }
    }
}
