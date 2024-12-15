namespace ReverseWords.UnitTests;

using Xunit;

public class WordReverserShould
{
    [Theory]
    [InlineData("a", "a")]
    [InlineData("ab", "ab")]
    [InlineData("abc", "abc")]
    public void NotReverseShortWords(string inputText, string expectedResult)
    {
        //Arrange

        //Act
        var result = WordReverser.Reverse(inputText);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("abcd", "dcba")]
    [InlineData("abcde", "edcba")]
    public void ReverseLongWords(string inputText, string expectedResult)
    {
        //Arrange

        //Act
        var result = WordReverser.Reverse(inputText);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ReverseLongWordsInSentense()
    {
        //Arrange
        const string text = "abc abcd ab abcde";
        const string expectedResult = "abc dcba ab edcba";

        //Act
        var result = WordReverser.Reverse(text);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData(" ", " ")]
    [InlineData("    ", "    ")]
    public void ReturnEmptyOrWhitespaceTextsAsIs(string inputText, string expectedResult)
    {
        //Arrange

        //Act
        var result = WordReverser.Reverse(inputText);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void PreserveWhitespacesInSentense()
    {
        //Arrange
        const string text = "abc abcd  ab   abcde";
        const string expectedResult = "abc dcba  ab   edcba";

        //Act
        var result = WordReverser.Reverse(text);

        //Assert
        Assert.Equal(expectedResult, result);
    }
}