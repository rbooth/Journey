using System.Text.RegularExpressions;

namespace Journey.Tests
{
    public static class StringExtensions
    {
        public static string UnCamel(this string input)
        {
            return Regex.Replace(input, @"[\p{Lu}_]", x => " " + x.Value).Trim();
        }
    }
}