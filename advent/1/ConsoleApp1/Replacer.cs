using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public static class Replacer
    {
        private static readonly IDictionary<string, string> _replacePatterns = new Dictionary<string, string>()
        {
            {"one", "1" },
            {"two", "2" },
            {"three", "3" },
            {"four", "4" },
            {"five", "5" },
            {"six", "6" },
            {"seven", "7" },
            {"eight", "8" },
            {"nine", "9" },
            {"zero", "0" }
        };

        public static string Replace(string stringForReplacement)
        {
            var stringVariableMatches = Regex.Replace(stringForReplacement, string.Join('|', _replacePatterns.Keys), m => _replacePatterns[m.Value]);
            return stringVariableMatches;
        }

        public static int CountAndReplace(string line)
        {
            var replacedLine = Replace(line);
            return Counter.Count(replacedLine);
        }
    }
}
