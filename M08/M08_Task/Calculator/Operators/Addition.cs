namespace Calculator.Operators
{
    internal class Addition : Operation
    {
        public override void PerformOperation(ClassLibrary.Stack<double> stack)
        {
            var first = stack.Pop();
            var second = stack.Pop();

            var res = first + second;

            stack.Push(res);
        }
    }
}
