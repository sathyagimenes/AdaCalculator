using AdaCalculator;
using Moq;

namespace AdaCalculatorTest
{
    public class AdaCalculatorTest
    {
        [Fact]
        public void Calculate_SumTwoNumbers_ReturnOperationAndResult()
        {
            // Arrange
            CalculatorMachine calcMach = new CalculatorMachine(new Calculator());
            // Act
            (string operation, double result) op = calcMach.Calculate("sum", 4, 3);
            // Assert
            Assert.Equal("sum", op.operation);
            Assert.Equal(7, op.result);
        }

        [Fact]
        public void Calculate_MultiplyTwoNumbers_ReturnOperationAndResult()
        {
            CalculatorMachine calcMach = new CalculatorMachine(new Calculator());

            (string operation, double result) op = calcMach.Calculate("multiply", 2, 4);

            Assert.Equal("multiply", op.operation);
            Assert.Equal(8, op.result);
        }

        [Theory]
        [InlineData(2, 4, -2)]
        [InlineData(2, 0, 2)]
        [InlineData(5, -4, 9)]
        public void Calculate_SubtractTwoNumbers_ReturnOperationAndResult(double n1, double n2, double expected)
        {
            CalculatorMachine calcMach = new CalculatorMachine(new Calculator());

            (string operation, double result) op = calcMach.Calculate("subtract", n1, n2);

            Assert.Equal("subtract", op.operation);
            Assert.Equal(expected, op.result);
        }

        [Fact]
        public void Calculate_DivideTwoNumbers_ReturnOperationAndResult()
        {
            CalculatorMachine calcMach = new CalculatorMachine(new Calculator());

            (string operation, double result) op = calcMach.Calculate("divide", 6, 2);

            Assert.Equal("divide", op.operation);
            Assert.Equal(3, op.result);
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