namespace TextFilter.TextFilters;

internal class RemoveCharacterFilter(char removeChar) : BaseTextFilter
{
    public override string ApplyFilter(string line)
    {
        //TODO removeChar will need to be escaped for special characters
        //breaking the pattern and searching and replace in one step

        var filteredText = TextEditService.RemoveWordContainingCharacter(line, removeChar);
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
