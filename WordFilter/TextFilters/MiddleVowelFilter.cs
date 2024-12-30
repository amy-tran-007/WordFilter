using System.Text;
using System.Text.RegularExpressions;

namespace TextFilter.TextFilters;

internal class MiddleVowelFilter : BaseTextFilter
{
    protected StringBuilder _middleVowelSb = new StringBuilder();
    //words less than 2 character length is excluded from filter as middle doesn't exist

    protected override bool ShouldWordBeFiltered(string word)
    {
        if (word.Length <= 2)
        {
            return false;
        }

        var middleCharacters = word.Length % 2 == 0 ? word.Substring(word.Length / 2 - 1, 2) : word.Substring(word.Length / 2, 1);
        return ContainsSomeVowels(middleCharacters);
    }
    private bool ContainsSomeVowels(string word)
    {
        var regex = @"[aeiou]";
        Match match = Regex.Match(word, regex, RegexOptions.IgnoreCase);
        return match.Success;
    }
}
