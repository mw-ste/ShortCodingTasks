using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryParser
{
    public static class DictionaryParser
    {
        public static Dictionary<string, string> Parse(string text)
        {
            return text.Split(';')
                .Where(pair => !string.IsNullOrWhiteSpace(pair))
                .Select(ParseKeyValuePair)
                .Aggregate(
                    new Dictionary<string, string>(),
                    AddKeyValuePairToDictionary);
        }

        private static (string key, string value) ParseKeyValuePair(string pair)
        {
            if (!pair.Contains('='))
            {
                throw new ArgumentException("No equals sign in pair");
            }

            var split = pair.Split('=', 2);
            var key = split[0].Trim();
            var value = split[1].Trim();

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("No key in pair");
            }

            return (key, value);
        }

        private static Dictionary<string, string> AddKeyValuePairToDictionary(
            Dictionary<string, string> dictionary,
            (string key, string value) keyValuePair)
        {
            var (key, value) = keyValuePair;
            dictionary[key] = value;
            return dictionary;
        }
    }
}
