namespace Task3.GameEntities
{
    internal abstract class Character : ObjectOnField, IMovable
    {
        protected int Speed { get; set; }

        public Character(int x, int y) : base(x, y)
        {
        }

        public void Move(int offsetX, int offsetY)
        {
            this.X = Utils.Clamp(this.X + offsetX * Speed, 0, Program.Width);
            this.Y = Utils.Clamp(this.Y + offsetY * Speed, 0, Program.Height);
        }
    }
}