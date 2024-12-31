namespace TextFilter.TextFilters;

internal class MiddleVowelFilter : BaseTextFilter
{
    //words less than 2 character length is excluded from filter as middle doesn't exist
    private string _searchForChars = "aeiou";
    protected override bool ShouldWordBeFiltered(string word)
    {
        if (word.Length <= 2)
        {
            return false;
        }

        var middleCharacters = word.Length % 2 == 0 ? word.Substring(word.Length / 2 - 1, 2)
                                                    : word.Substring(word.Length / 2, 1);

        return TextEditService.ContainsAnyCharacter(middleCharacters, _searchForChars);
    }
}
