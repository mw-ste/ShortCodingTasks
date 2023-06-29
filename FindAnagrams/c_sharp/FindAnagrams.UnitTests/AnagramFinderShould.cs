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
    
    [Fact]
    public void NotCountDuplicatesAsAnagram()
    {
        //Arrange
        var input = "one one one";

        //Act
        var result = AnagramFinder.Find(input);

        //Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void NotRecognizeSameWordWithDifferentCasingAsAnagram()
    {
        //Arrange
        var input = "one ONE oNe";

        //Act
        var result = AnagramFinder.Find(input);

        //Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void RecognizeAnagramsOfSameWordAsAnagrams()
    {
        //Arrange
        var input = "one neo eon";

        //Act
        var result = AnagramFinder.Find(input);

        //Assert
        Assert.True(result.Single().SequenceEqual(new[] { "one", "neo", "eon" }));
    }
    
    [Fact]
    public void ReturnAnagramsOfSeveralWords()
    {
        //Arrange
        var input = "one neo eon two wot three eerht what";

        //Act
        var result = AnagramFinder.Find(input);

        //Assert
        Assert.Equal(3, result.Count);
        Assert.Contains(result, l => l.SequenceEqual(new[] { "one", "neo", "eon" }));
        Assert.Contains(result, l => l.SequenceEqual(new[] { "two", "wot" }));
        Assert.Contains(result, l => l.SequenceEqual(new[] { "three", "eerht" }));
    }
    
    [Fact]
    public void IgnoreAdditionalWhitespaces()
    {
        //Arrange
        var input = "one  one    one    ";

        //Act
        var result = AnagramFinder.Find(input);

        //Assert
        Assert.True(result.Single().SequenceEqual(new[] { "one", "one", "one" }));
    }
}