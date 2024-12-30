using System.Text.RegularExpressions;

namespace TextFilter.Helpers;

internal static class StringHelper
{
    public static string ReplaceMultipleWhitespace(this string line)
    {
        var regex = @"\s+\s{1,}";
        return Regex.Replace(line, regex, " ", RegexOptions.IgnoreCase).Trim();
    }
    public static IReadOnlyCollection<(string word, string splitBy)>? ExtractAlphaNumericCharacters(this string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return null;
        }

        Regex nonAlphaNumeric = new Regex("[^\\w*]+");
        var words = nonAlphaNumeric.Split(line);

        MatchCollection matches = nonAlphaNumeric.Matches(line);
        var wordList = new List<(string word, string splitBy)>();
        for (int i = 0; i < matches.Count; i++)
        {
            wordList.Add((word: words[i], splitBy: matches[i].Value));
        }

        wordList.Add((word: words[matches.Count], splitBy: string.Empty));
        return wordList;
    }
}
