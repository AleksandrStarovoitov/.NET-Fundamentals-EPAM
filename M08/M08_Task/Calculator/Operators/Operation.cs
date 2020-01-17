namespace Calculator.Operators
{
    abstract class Operation
    {
        public abstract void PerformOperation(ClassLibrary.Stack<double> stack);
    }
}
