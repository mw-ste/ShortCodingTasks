namespace FindAnagrams;

public static class AnagramFinder
{
    public static List<List<string>> Find(string text)
    {
        var keyValuePairs = text
            .Split(' ')
            .Where(word => !string.IsNullOrWhiteSpace(word))
            .Select(CreateKeyValuePair);
            
        var groups = keyValuePairs
            .GroupBy(kvp => kvp.Key)
            .Select(ExpandGroup)
            .Where(groupMembers => groupMembers.Count > 1)
            .ToList();

        return groups;
    }

    private static List<string> ExpandGroup(IGrouping<string, KeyValuePair<string, string>> grouping)
    {
        return grouping
            .AsEnumerable()
            .Select(kvp => kvp.Value)
            .Distinct()
            .ToList();
    }

    private static KeyValuePair<string, string> CreateKeyValuePair(string text)
    {
        var charArray = text.ToLower().ToCharArray();
        Array.Sort(charArray);
        var key = string.Join("", charArray);
        return new KeyValuePair<string, string>(key, text);
    }
}
