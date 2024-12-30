using System.Text.RegularExpressions;
using TextFilter.Helpers;

namespace TextFilter.TextFilters;

internal class RemoveCharacterFilter(char removeChar) : BaseTextFilter
{
    public override string ApplyFilter(string line)
    {
        //TODO removestring will need to be escaped for special characters
        if (line == null)
        {
            return String.Empty;
        }
        var regex = $@"\w*{removeChar}\w*";
        var filteredText = Regex.Replace(line, regex, "", RegexOptions.IgnoreCase).ReplaceMultipleWhitespace();
        if (NextFilter != null)
        {
            return $"{NextFilter.ApplyFilter(filteredText)}";
        }
        return filteredText;
    }

    protected override bool ShouldWordBeFiltered(string word)
    {
        return false;
    }
}
