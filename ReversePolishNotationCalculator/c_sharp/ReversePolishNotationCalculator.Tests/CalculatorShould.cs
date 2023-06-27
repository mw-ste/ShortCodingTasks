namespace ReversePolishNotationCalculator.Tests;

using Xunit;

public class CalculatorShould
{
    [Fact]
    public void SumUpTwoNumbers()
    {
        //Arrange
        const string calculation = "4 3 +";
        const double expectedResult = 7;

        //Act
        var result = Calculator.Solve(calculation);

        //Assert
        Assert.Equal(expectedResult, result);
    }
}