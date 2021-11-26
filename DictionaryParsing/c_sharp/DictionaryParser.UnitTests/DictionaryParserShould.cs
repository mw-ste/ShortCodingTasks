
namespace DictionaryParser.UnitTests
{
    using System.Collections.Generic;
    using System;
    using Xunit;

    public class DictionaryParserShould
    {
        #region test helpers

        private static void AssertDictionaryContainsKeyValuePairs(
            Dictionary<string, string> dictionary,
            params (string key, string value)[] expectedKeyValuePairs)
        {
            Assert.Equal(expectedKeyValuePairs.Length, dictionary.Count);
            foreach (var (key, value) in expectedKeyValuePairs)
            {
                Assert.Contains(dictionary, kvp =>
                    kvp.Key == key &&
                    kvp.Value == value);
            }
        }

        #endregion

        #region given test cases

        [Fact]
        public void ParseEasyString()
        {
            const string inputText = "a=1;b=2;c=3";

            var result = DictionaryParser.Parse(inputText);

            AssertDictionaryContainsKeyValuePairs(result,
                ("a", "1"),
                ("b", "2"),
                ("c", "3"));
        }

        [Fact]
        public void ParseStringWithDuplicateKey()
        {
            const string inputText = "a=1;a=2";

            var result = DictionaryParser.Parse(inputText);

            AssertDictionaryContainsKeyValuePairs(result, ("a", "2"));
        }

        [Fact]
        public void ParseStringWithSpaces()
        {
            const string inputText = "a = 1; b = 2";

            var result = DictionaryParser.Parse(inputText);

            AssertDictionaryContainsKeyValuePairs(result,
                ("a", "1"),
                ("b", "2"));
        }

        [Fact]
        public void ParseStringWithExtraSemiColon()
        {
            const string inputText = "a=1;;b=2";

            var result = DictionaryParser.Parse(inputText);

            AssertDictionaryContainsKeyValuePairs(result,
                ("a", "1"),
                ("b", "2"));
        }

        [Fact]
        public void InsertEmptyValueForMissingInputValue()
        {
            const string inputText = "a=";

            var result = DictionaryParser.Parse(inputText);

            AssertDictionaryContainsKeyValuePairs(result, ("a", ""));
        }

        [Fact]
        public void CreateEmptyDictionaryForEmptyInputString()
        {
            const string inputText = "";

            var result = DictionaryParser.Parse(inputText);

            Assert.Empty(result);
        }

        [Fact]
        public void UseAdditionalEqualsSignsAsPartOfValue()
        {
            const string inputText = "a==1";

            var result = DictionaryParser.Parse(inputText);

            AssertDictionaryContainsKeyValuePairs(result, ("a", "=1"));
        }

        [Fact]
        public void RaiseExceptionForMissingInputKey()
        {
            Assert.Throws<ArgumentException>(() =>
                DictionaryParser.Parse("=1"));
        }

        [Fact]
        public void RaiseExceptionForMissingEqualsSign()
        {
            Assert.Throws<ArgumentException>(() =>
                DictionaryParser.Parse("a"));
        }

        #endregion

        #region additional tests

        [Fact]
        public void ParseDictionaryForAllProblemsCombined()
        {
            const string inputText = " a = 1 ; ; c =  ; ; b = = 2 ";

            var result = DictionaryParser.Parse(inputText);

            AssertDictionaryContainsKeyValuePairs(result,
                ("a", "1"),
                ("b", "= 2"),
                ("c", ""));
        }

        #endregion
    }
}
