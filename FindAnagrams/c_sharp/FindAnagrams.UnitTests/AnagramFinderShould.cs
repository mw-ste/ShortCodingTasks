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
    public void IgnoreAdditionalWhitespaces()
    {
        //Arrange
        var input = " one  neo   eon ";

        //Act
        var result = AnagramFinder.Find(input);

        //Assert
        Assert.True(result.Single().SequenceEqual(new[] { "one", "neo", "eon" }));
    }
    
    [Fact]
    public void RecognizeSameWordWithDifferentCasingAsAnagram()
    {
        //Arrange
        var input = "one ONE oNe";

        //Act
        var result = AnagramFinder.Find(input);

        //Assert
        Assert.True(result.Single().SequenceEqual(new[] { "one", "ONE", "oNe" }));
    }

    [Fact]
    public void ReturnAnagramsOfSeveralWords()
    {
        //Arrange
        var input = "one two neo wot";

        //Act
        var result = AnagramFinder.Find(input);

        //Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(result, l => l.SequenceEqual(new[] { "one", "neo" }));
        Assert.Contains(result, l => l.SequenceEqual(new[] { "two", "wot" }));
    }

    [Fact]
    public void FindAllAnagrams()
    {
        //Arrange
        var input = "one two  three NEO eerht   wot what ONE one";

        //Act
        var result = AnagramFinder.Find(input);

        //Assert
        Assert.Equal(3, result.Count);
        Assert.Contains(result, l => l.SequenceEqual(new[] { "one", "NEO", "ONE" }));
        Assert.Contains(result, l => l.SequenceEqual(new[] { "two", "wot" }));
        Assert.Contains(result, l => l.SequenceEqual(new[] { "three", "eerht" }));
    }
}