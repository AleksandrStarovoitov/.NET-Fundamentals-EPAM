namespace Task3.GameEntities.Bonuses
{
    internal class Banana : Bonus
    {
        public Banana(int x, int y) : base(x, y)
        {
            this.BonusPoints = 15;
        }
    }
}