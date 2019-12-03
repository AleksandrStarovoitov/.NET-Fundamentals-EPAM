using System;

namespace Task3.GameEntities.Monsters 
{
    internal abstract class Monster : Character
    {
        public Monster(int x, int y) : base(x, y)
        {
        }

        public void Eat(Player player)
        {
            if (player is null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            player.Health = 0;
        }
    }
}