using FluentAssertions;

namespace DictionaryParser.Fluent.UnitTests;

using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;

public class DictionaryParserShould
{
    #region test helpers

    private static Dictionary<string, string> CreateExpectedResult(
        params (string key, string value)[] expectedKeyValuePairs)
    {
        return expectedKeyValuePairs.ToDictionary(
            kvp => kvp.key,
            kvp => kvp.value);
    }

    #endregion

    [Fact]
    public void ParseEasyString()
    {
        // Arrange
        const string inputText = "a=1;b=2;c=3";
        var expectedResult = CreateExpectedResult(
            ("a", "1"),
            ("b", "2"),
            ("c", "3"));

        // Act
        var result = DictionaryParser.Parse(inputText);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void ParseStringWithDuplicateKey()
    {
        // Arrange
        const string inputText = "a=1;a=2";
        var expectedResult = CreateExpectedResult(("a", "2"));

        // Act
        var result = DictionaryParser.Parse(inputText);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void ParseStringWithSpaces()
    {
        // Arrange
        const string inputText = "a = 1; b = 2";
        var expectedResult = CreateExpectedResult(
            ("a", "1"),
            ("b", "2"));

        // Act
        var result = DictionaryParser.Parse(inputText);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void ParseStringWithExtraSemiColon()
    {
        // Arrange
        const string inputText = "a=1;;b=2";
        var expectedResult = CreateExpectedResult(
            ("a", "1"),
            ("b", "2"));

        // Act
        var result = DictionaryParser.Parse(inputText);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void InsertEmptyValueForMissingInputValue()
    {
        // Arrange
        const string inputText = "a=";
        var expectedResult = CreateExpectedResult(("a", ""));

        // Act
        var result = DictionaryParser.Parse(inputText);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void CreateEmptyDictionaryForEmptyInputString()
    {
        // Arrange
        const string inputText = "";

        // Act
        var result = DictionaryParser.Parse(inputText);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void UseAdditionalEqualsSignsAsPartOfValue()
    {
        // Arrange
        const string inputText = "a==1";
        var expectedResult = CreateExpectedResult(("a", "=1"));

        // Act
        var result = DictionaryParser.Parse(inputText);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void RaiseExceptionForMissingInputKey()
    {
        // Arrange
        var missingKeyAction = () => DictionaryParser.Parse("=1");

        // Act
        // Assert
        missingKeyAction.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void RaiseExceptionForMissingEqualsSign()
    {
        // Arrange
        var missingEqualsSignAction = () => DictionaryParser.Parse("a");

        // Act
        // Assert
        missingEqualsSignAction.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ParseDictionaryForAllProblemsCombined()
    {
        // Arrange
        const string inputText = " a = 1 ; ; c =  ; ; b = = 2 ";
        var expectedResult = CreateExpectedResult(
            ("a", "1"),
            ("b", "= 2"),
            ("c", ""));

        // Act
        var result = DictionaryParser.Parse(inputText);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }
}
