namespace FindAnagrams;

public static class AnagramFinder
{
    public static List<List<string>> Find(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return new List<List<string>>();
        }

        var parts = text
            .Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x =>
            {
                var charArray = x.ToLower().ToCharArray();
                Array.Sort(charArray);
                return (Key: charArray, x);
            });

        Console.WriteLine(parts);
        throw new NotImplementedException();
    }
}
