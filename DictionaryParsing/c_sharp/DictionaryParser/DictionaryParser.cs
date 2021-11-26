using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryParser
{
    public static class DictionaryParser
    {
        public static Dictionary<string, string> Parse(string text)
        {
            var dictionary = new Dictionary<string, string>();

            text.Split(";")
                .Where(pair => !string.IsNullOrEmpty(pair.Trim()))
                .Select(ParseKeyValuePair)
                .ToList()
                .ForEach(kvp => dictionary[kvp.key] = kvp.value);

            return dictionary;
        }

        private static (string key, string value) ParseKeyValuePair(string pair)
        {
            if (!pair.Contains("="))
            {
                throw new ArgumentException("No equals sign in pair");
            }

            var split = pair.Split("=", 2);
            var key = split[0].Trim();
            var value = split[1].Trim();

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("No key in pair");
            }

            return (key, value);
        }
    }
}
