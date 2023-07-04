namespace FindAnagrams;

public static class AnagramFinder
{
    public static List<List<string>> Find(string text)
    {
        return text
            .Split(' ')
            .Where(word => !string.IsNullOrWhiteSpace(word))
            .Distinct()
            .GroupBy(GetGroupingKey)
            .Select(grouping => grouping.ToList())
            .Where(groupMembers => groupMembers.Count > 1)
            .ToList();
    }

    private static string GetGroupingKey(string text)
    {
        return text
            .ToLower()
            .ToCharArray()
            .OrderBy(x => x)
            .Aggregate("", (word, c) => word + c);
    }
}
