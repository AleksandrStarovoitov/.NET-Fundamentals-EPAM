using NUnit.Framework;
using Calculator;

namespace Calculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Calculate_NullString_ThrowArgumentException()
        {
            string expr = null;

            Assert.That(() => Calculator.Calculate(expr),
                Throws.ArgumentNullException.
                    With.Message.
                    EqualTo("Value cannot be null.\r\nParameter name: expr"));
        }

        [Test]
        public void Calculate_TooManyOperations_ThrowArgumentException()
        {
            var expr = "5 5 + +";

            Assert.That(() => Calculator.Calculate(expr),
                Throws.ArgumentException.
                    With.Message.
                    EqualTo("Invalid expression. Operations > numbers."));
        }

        [Test]
        public void Calculate_TooManyNumbers_ThrowArgumentException()
        {
            var expr = "5 5 5 +";

            Assert.That(() => Calculator.Calculate(expr),
                Throws.ArgumentException.
                    With.Message.
                    EqualTo("Invalid expression. Numbers > operations."));
        }

        [Test]
        public void Calculate_InvalidEntry_ThrowArgumentException()
        {
            var expr = "5 5 5+ +";

            Assert.That(() => Calculator.Calculate(expr),
                Throws.ArgumentException.
                    With.Message.
                    EqualTo("Invalid entry: 5+"));
        }

        [Test]
        public void Calculate_ValidExpr_Returns14()
        {
            var expr = "5 1 2 + 4 * + 3 -";

            var res = Calculator.Calculate(expr);

            Assert.That(res, Is.EqualTo(14));
        }

        [Test]
        public void Calculate_EmptyExpr_Returns0()
        {
            var expr = "";

            var res = Calculator.Calculate(expr);

            Assert.That(res, Is.EqualTo(0));
        }
    }
}
