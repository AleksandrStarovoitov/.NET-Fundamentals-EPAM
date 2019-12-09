namespace M04_Task1_and_Task2.Shapes
{
    internal abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();

        public override string ToString()
        {
            var type = this.GetType();
            return $"{type.Name} perimeter: {this.GetPerimeter()} \n" + 
                   $"{type.Name} area: {this.GetArea()}";
        }
    }
}
