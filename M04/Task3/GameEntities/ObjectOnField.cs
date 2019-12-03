namespace Task3.GameEntities
{
    internal abstract class ObjectOnField
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int Image { get; protected set; }

        public ObjectOnField(int x, int y )
        {
            this.X = Utils.Clamp(x, 0, Program.Width);
            this.Y = Utils.Clamp(y, 0, Program.Height);
        }
    }
}