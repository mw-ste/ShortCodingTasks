namespace FindAnagrams;

public static class AnagramFinder
{
    public static List<List<string>> Find(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return new List<List<string>>();
        }

        var keyValuePairs = text
            .Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(CreateKeyValuePair);
            
        var groups = keyValuePairs
            .GroupBy(x => x.Key)
            .Select(x => x.AsEnumerable().Select(y => y.Value).ToList())
            .Where(x => x.Count > 1)
            .ToList();

        return groups;
    }

    private static KeyValuePair<string, string> CreateKeyValuePair(string text)
    {
        var charArray = text.ToLower().ToCharArray();
        Array.Sort(charArray);
        var key = string.Join("", charArray);
        return new KeyValuePair<string, string>(key, text);
    }
}
