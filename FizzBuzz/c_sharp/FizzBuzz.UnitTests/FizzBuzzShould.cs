using System;
using System.IO;
using Xunit;
using FizzBuzz;

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

        private string GetConsoleOutput() => _stringWriter.ToString();

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void PrintFizzForNumbersDivisibleByThree(int inputValue)
        {
            // Arrange

            //Act
            FizzBuzz.Run(new [] {inputValue});

            //Assert
            Assert.Equal("Fizz\n", GetConsoleOutput());
        }
    }
}