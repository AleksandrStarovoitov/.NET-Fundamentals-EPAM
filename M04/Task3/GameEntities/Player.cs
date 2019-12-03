using System;
using Task3.GameEntities.Bonuses;

namespace Task3.GameEntities
{
    internal class Player : Character
    {
        public int Health { get; set; }
        public int BonusPoints { get; set; }

        public Player(int x, int y) : base(x, y)
        {
        }

        public void ConsumeBonus(Bonus bonus)
        {
            if (bonus is null)
            {
                throw new ArgumentNullException(nameof(bonus));
            }

            this.BonusPoints += bonus.BonusPoints;
        }
    }
}