using System;
using System.IO;
using System.Linq;
using FizzBuzz;
using Xunit;

namespace FizzBuzz.UnitTests
{
    public class FizzBuzzShould
    {
        private readonly StringWriter _stringWriter;

        public FizzBuzzShould()
        {
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }

        private static void RunFizzBuzz(params int[] values) => FizzBuzz.Run(values);

        private string GetConsoleOutput() => _stringWriter.ToString();

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void PrintFizzForNumbersDivisibleByThree(int inputValue)
        {
            // Arrange
            var expectedOutput = "Fizz\n";

            //Act
            RunFizzBuzz(inputValue);

            //Assert
            Assert.Equal(expectedOutput, GetConsoleOutput());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void PrintBuzzForNumbersDivisibleByFive(int inputValue)
        {
            // Arrange
            var expectedOutput = "Buzz\n";

            //Act
            RunFizzBuzz(inputValue);

            //Assert
            Assert.Equal(expectedOutput, GetConsoleOutput());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(15)]
        [InlineData(30)]
        public void PrintFizzBuzzForNumbersDivisibleByThreeAndFive(int inputValue)
        {
            // Arrange
            var expectedOutput = "FizzBuzz\n";

            //Act
            RunFizzBuzz(inputValue);

            //Assert
            Assert.Equal(expectedOutput, GetConsoleOutput());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public void PrintNumberForNumbersNotDivisibleByThreeOrFive(int inputValue)
        {
            // Arrange
            var expectedOutput = $"{inputValue}\n";

            //Act
            RunFizzBuzz(inputValue);

            //Assert
            Assert.Equal(expectedOutput, GetConsoleOutput());
        }

        [Fact]
        public void PrintCorrectOutputForSequenceOfNumbers()
        {
            // Arrange
            var input = Enumerable.Range(1, 16);
            var expectedOutput = string.Join('\n', new[]
            {
                "1",
                "2",
                "Fizz",
                "4",
                "Buzz",
                "Fizz",
                "7",
                "8",
                "Fizz",
                "Buzz",
                "11",
                "Fizz",
                "13",
                "14",
                "FizzBuzz",
                "16\n"
            });

            // Act
            RunFizzBuzz(input.ToArray());

            //Assert
            Assert.Equal(expectedOutput, GetConsoleOutput());
        }
    }
}