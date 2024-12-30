using System.Text.RegularExpressions;

namespace TextFilter.Helpers;

internal static class StringHelper
{
    public static string ReplaceMultipleWhitespace(this string line)
    {
        var regex = @"\s+\s{1,}";
        return Regex.Replace(line, regex, " ", RegexOptions.IgnoreCase).Trim();
    }
}
