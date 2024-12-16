namespace Rot13.UnitTests;

using Xunit;

public class Rot13EncryptionShould
{
    [Theory]
    [InlineData("a", "n")]
    [InlineData("m", "z")]
    [InlineData("n", "a")]
    [InlineData("z", "m")]
    public void EncryptSingleLowerCaseCharacters(string text, string expectedResult)
    {
        //Arrange

        //Act
        var result = Rot13Encryption.Encrypt(text);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("A", "N")]
    [InlineData("M", "Z")]
    [InlineData("N", "A")]
    [InlineData("Z", "M")]
    public void EncryptSingleUpperCaseCharacters(string text, string expectedResult)
    {
        //Arrange

        //Act
        var result = Rot13Encryption.Encrypt(text);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void EncryptWholeWord()
    {
        //Arrange
        var text = "Hello";
        var expectedResult = "Uryyb";

        //Act
        var result = Rot13Encryption.Encrypt(text);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void EncryptSentenceWithSpaces()
    {
        //Arrange
        var text = "Hello my  name is\ttest";
        var expectedResult = "Uryyb zl  anzr vf\tgrfg";

        //Act
        var result = Rot13Encryption.Encrypt(text);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData(".", ".")]
    [InlineData(" ", " ")]
    [InlineData("!", "!")]
    [InlineData("ß", "ß")]
    [InlineData("Ä", "Ä")]
    public void PreserveNonLatinAlphabetCharacters(string text, string expectedResult)
    {
        //Arrange

        //Act
        var result = Rot13Encryption.Encrypt(text);

        //Assert
        Assert.Equal(expectedResult, result);
    }
}
