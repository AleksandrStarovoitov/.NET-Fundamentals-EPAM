using Task3.GameEntities.Monsters;
using Task3.GameEntities;
using Task3.GameEntities.Obstacles;
using Task3.GameEntities.Bonuses;

namespace Task3
{
    internal class Program
    {
        public const int Width = 512;
        public const int Height = 512;

        static void Main(string[] args)
        {
            var characters = new Character[]
            {
                new Wolf(0,3),
                new Bear(0,1),
                new Player(0,0)
            };

            var objects = new ObjectOnField[]
            {
                characters[0],
                characters[1],
                characters[2],
                new Tree(4, 4),
                new Apple(5, 5),
                new Bear(3, 3)
            };

            foreach (var character in characters)
            {
                character.Move(1, 2);
            }
        }
    }
}
