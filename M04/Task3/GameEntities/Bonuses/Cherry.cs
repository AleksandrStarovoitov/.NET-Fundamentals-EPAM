namespace Task3.GameEntities.Bonuses
{
    internal class Cherry : Bonus
    {
        public Cherry(int x, int y) : base(x, y)
        {
            this.BonusPoints = 10;
        }
    }
}