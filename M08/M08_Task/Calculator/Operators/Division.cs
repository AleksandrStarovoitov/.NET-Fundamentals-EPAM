namespace Calculator.Operators
{
    internal class Division : Operation
    {
        public override void PerformOperation(ClassLibrary.Stack<double> stack)
        {
            var first = stack.Pop();
            var second = stack.Pop();

            var res = second / first;

            stack.Push(res);
        }
    }
}
