namespace ReverseWords;

using System.Linq;

public class WordReverser
{
    const char delimiter = ' ';
    const int maxSize = 3;

    public static string Reverse(string text)
    {
        return string.Join(delimiter, text.Split(delimiter).Select(ReverseIfLong));
    }

    private static string ReverseIfLong(string text)
    {
        return text.Length > maxSize
            ? string.Join("", text.Reverse())
            : text;
    }
}
