namespace ReverseWords;

using System.Linq;

public class WordReverser
{
    private const char _delimiter = ' ';
    private const int _maxSize = 3;

    public static string Reverse(string text)
    {
        return string.Join(_delimiter, text.Split(_delimiter).Select(ReverseIfLong));
    }

    private static string ReverseIfLong(string text)
    {
        return text.Length > _maxSize
            ? string.Join("", text.Reverse())
            : text;
    }
}
