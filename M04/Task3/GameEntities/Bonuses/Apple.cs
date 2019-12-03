namespace Task3.GameEntities.Bonuses
{
    internal class Apple : Bonus
    {
        public Apple(int x, int y) : base(x, y)
        {
            this.BonusPoints = 20;
        }
    }
}