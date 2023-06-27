using System;
using Xunit;

namespace ReversePolishNotationCalculator.Tests;

public class CalculatorShould
{
    [Fact]
    public void DirectlyReturnSingleNumber()
    {
        //Arrange
        const string calculation = "5";
        const double expectedResult = 5;

        //Act
        var result = Calculator.Solve(calculation);

        //Assert
        Assert.Equal(expectedResult, result);
    }

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

    [Fact]
    public void DeductTwoNumbers()
    {
        //Arrange
        const string calculation = "4 3 -";
        const double expectedResult = 1;

        //Act
        var result = Calculator.Solve(calculation);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void DeductTwoNumbersWithNegativeResult()
    {
        //Arrange
        const string calculation = "3 4 -";
        const double expectedResult = -1;

        //Act
        var result = Calculator.Solve(calculation);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void SumUpTwoNumbersWithExtraSpaces()
    {
        //Arrange
        const string calculation = " 4   3  + ";
        const double expectedResult = 7;

        //Act
        var result = Calculator.Solve(calculation);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void SumUpTwoNegativeNumbers()
    {
        //Arrange
        const string calculation = "-4 -3 +";
        const double expectedResult = -7;

        //Act
        var result = Calculator.Solve(calculation);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void CalculateWithSeveralNumbers()
    {
        //Arrange
        const string calculation = " 4  3 +    5 + 11  + 33 - ";
        const double expectedResult = -10;

        //Act
        var result = Calculator.Solve(calculation);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("4 3 x")]
    [InlineData("1 b +")]
    [InlineData("1 + 2")]
    [InlineData("4 3 + 5")]
    public void RaiseArgumentExceptionForInvalidCalculations(string faultyCalculation)
    {
        //Arrange
        //Act
        //Assert
        Assert.Throws<ArgumentException>(
            () => Calculator.Solve(faultyCalculation));
    }

    #region additional tests for multiplication and division

    [Fact]
    public void MultiplyTwoNumbers()
    {
        //Arrange
        const string calculation = "4 3 *";
        const double expectedResult = 12;

        //Act
        var result = Calculator.Solve(calculation);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void DivideTwoNumbers()
    {
        //Arrange
        const string calculation = "10 4 /";
        const double expectedResult = 2.5;

        //Act
        var result = Calculator.Solve(calculation);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void CalculateResultInGivenOrder()
    {
        //Arrange
        const string calculation = "10 4 / 2 + 4 * 3 - 5 /";
        const double expectedResult = 3;

        //Act
        var result = Calculator.Solve(calculation);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    #endregion
}