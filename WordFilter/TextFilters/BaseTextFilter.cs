using System.Text;
using System.Text.RegularExpressions;
using TextFilter.Helpers;

namespace TextFilter.TextFilters;

internal abstract class BaseTextFilter
{
    protected BaseTextFilter NextFilter = default!;

    public BaseTextFilter SetNextFilter(BaseTextFilter nextFilter)
    {
        NextFilter = nextFilter;
        return this.NextFilter;
    }

    protected abstract bool ShouldWordBeFiltered(string word);

    public virtual string ApplyFilter(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return string.Empty;
        }
        var regExSb = new StringBuilder();

        Regex nonAlphaNumeric = new Regex("[^\\w*]+");
        var words = nonAlphaNumeric.Split(line);
        foreach (var word in words)
        {
            if (ShouldWordBeFiltered(word) && string.IsNullOrWhiteSpace(word) == false)
            {
                regExSb.Append($"|\\b({word})\\b");
            }
        }

        var regex = regExSb.ToString();
        var filteredText = string.IsNullOrEmpty(regex) ? line :
                Regex.Replace(line, regex.Substring(1), "").ReplaceMultipleWhitespace();

        if (NextFilter != null)
        {
            return $"{NextFilter.ApplyFilter(filteredText)}";
        }
        return filteredText;
    }
}
