using Xunit;

namespace FindAnagrams.UnitTests;

public class AnagramFinderShould
{
    [Fact]
    public void ReturnEmptyResultForEmptyInput()
    {
        //Arrange
        var input = "";

        //Act
        var result = AnagramFinder.Find(input);

        //Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void ReturnEmptyResultWhenNoAnagramsAreGiven()
    {
        //Arrange
        var input = "one two three";

        //Act
        var result = AnagramFinder.Find(input);

        //Assert
        Assert.Empty(result);
    }
}