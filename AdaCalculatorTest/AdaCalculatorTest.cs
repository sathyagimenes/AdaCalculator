using AdaCalculator;
using Moq;

namespace AdaCalculatorTest
{
    public class AdaCalculatorTest
    {
        [Theory]
        [InlineData(2, -4, -2)]
        [InlineData(2, 0, 2)]
        [InlineData(5.5, 3.5, 9)]
        public void Calculate_SumTwoNumbers_ReturnOperationAndResult(double n1, double n2, double expected)
        {
            // Arrange
            CalculatorMachine calcMach = new CalculatorMachine(new Calculator());
            // Act
            (string operation, double result) op = calcMach.Calculate("sum", n1, n2);
            // Assert
            Assert.Equal("sum", op.operation);
            Assert.Equal(expected, op.result);
        }

        [Theory]
        [InlineData(2, -4, -8)]
        [InlineData(2, 0, 0)]
        [InlineData(1.1, 5, 5.5)]
        public void Calculate_MultiplyTwoNumbers_ReturnOperationAndResult(double n1, double n2, double expected)
        {
            CalculatorMachine calcMach = new CalculatorMachine(new Calculator());

            (string operation, double result) op = calcMach.Calculate("multiply", n1, n2);

            Assert.Equal("multiply", op.operation);
            Assert.Equal(expected, op.result);
        }

        [Theory]
        [InlineData(2, 4, -2)]
        [InlineData(2, 0, 2)]
        [InlineData(5.5, -4.5, 10)]
        public void Calculate_SubtractTwoNumbers_ReturnOperationAndResult(double n1, double n2, double expected)
        {
            CalculatorMachine calcMach = new CalculatorMachine(new Calculator());

            (string operation, double result) op = calcMach.Calculate("subtract", n1, n2);

            Assert.Equal("subtract", op.operation);
            Assert.Equal(expected, op.result);
        }

        [Theory]
        [InlineData(2, -4, -0.5)]
        [InlineData(800, 2, 400)]
        [InlineData(10.2, 2, 5.1)]
        public void Calculate_DivideTwoNumbers_ReturnOperationAndResult(double n1, double n2, double expected)
        {
            CalculatorMachine calcMach = new CalculatorMachine(new Calculator());

            (string operation, double result) op = calcMach.Calculate("divide", n1, n2);

            Assert.Equal("divide", op.operation);
            Assert.Equal(expected, op.result);
        }

        [Fact]
        public void Calculate_DivideTwoNumbers_CheckInvocationWithMoq()
        {
            Mock<ICalculator> mock = new Mock<ICalculator>();
            mock.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("divide", 3));
            CalculatorMachine calcMach = new CalculatorMachine(mock.Object);

            (string operacao, double resultado) op = calcMach.Calculate("divide", 6, 2);

            mock.Verify(x => x.Calculate("divide", 6, 2), Times.Once);
        }
    }
}