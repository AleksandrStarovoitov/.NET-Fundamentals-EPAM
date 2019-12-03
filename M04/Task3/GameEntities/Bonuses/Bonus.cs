namespace Task3.GameEntities.Bonuses
{
    internal abstract class Bonus : ObjectOnField
    {
        public int BonusPoints { get; set; }

        public Bonus(int x, int y) : base(x, y)
        {
        }
    }
}