using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DictionaryParser.UnitTests
{
    public class DictionaryParserShould
    {
        #region test helpers

        private static void AssertDictionaryContainsKeyValuePairs(
            Dictionary<string, string> dictionary,
            params (string key, string value)[] expectedKeyValuePairs)
        {
            var expectedDictionary = expectedKeyValuePairs.ToDictionary(
                kvp => kvp.key,
                kvp => kvp.value);

            Assert.Equal(expectedDictionary, dictionary);
        }

        #endregion

        [Fact]
        public void ParseEasyString()
        {
            // Arrange
            const string inputText = "a=1;b=2;c=3";

            // Act
            var result = DictionaryParser.Parse(inputText);

            // Assert
            AssertDictionaryContainsKeyValuePairs(result,
                ("a", "1"),
                ("b", "2"),
                ("c", "3"));
        }

        [Fact]
        public void ParseStringWithDuplicateKey()
        {
            // Arrange
            const string inputText = "a=1;a=2";

            // Act
            var result = DictionaryParser.Parse(inputText);

            // Assert
            AssertDictionaryContainsKeyValuePairs(result, ("a", "2"));
        }

        [Fact]
        public void ParseStringWithSpaces()
        {
            // Arrange
            const string inputText = "a = 1; b = 2";

            // Act
            var result = DictionaryParser.Parse(inputText);

            // Assert
            AssertDictionaryContainsKeyValuePairs(result,
                ("a", "1"),
                ("b", "2"));
        }

        [Fact]
        public void ParseStringWithExtraSemiColon()
        {
            // Arrange
            const string inputText = "a=1;;b=2";

            // Act
            var result = DictionaryParser.Parse(inputText);

            // Assert
            AssertDictionaryContainsKeyValuePairs(result,
                ("a", "1"),
                ("b", "2"));
        }

        [Fact]
        public void InsertEmptyValueForMissingInputValue()
        {
            // Arrange
            const string inputText = "a=";

            // Act
            var result = DictionaryParser.Parse(inputText);

            // Assert
            AssertDictionaryContainsKeyValuePairs(result, ("a", ""));
        }

        [Fact]
        public void CreateEmptyDictionaryForEmptyInputString()
        {
            // Arrange
            const string inputText = "";

            // Act
            var result = DictionaryParser.Parse(inputText);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void UseAdditionalEqualsSignsAsPartOfValue()
        {
            // Arrange
            const string inputText = "a==1";

            // Act
            var result = DictionaryParser.Parse(inputText);

            // Assert
            AssertDictionaryContainsKeyValuePairs(result, ("a", "=1"));
        }

        [Fact]
        public void RaiseExceptionForMissingInputKey()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() =>
                DictionaryParser.Parse("=1"));
        }

        [Fact]
        public void RaiseExceptionForMissingEqualsSign()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() =>
                DictionaryParser.Parse("a"));
        }

        [Fact]
        public void ParseDictionaryForAllProblemsCombined()
        {
            // Arrange
            const string inputText = " a = 1 ; ; c =  ; ; b = = 2 ";

            // Act
            var result = DictionaryParser.Parse(inputText);

            // Assert
            AssertDictionaryContainsKeyValuePairs(result,
                ("a", "1"),
                ("b", "= 2"),
                ("c", ""));
        }
    }
}
