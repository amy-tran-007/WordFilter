namespace TextFilter.TextFilters;

internal class LengthFilter(int minSize) : BaseTextFilter
{
    protected override bool ShouldWordBeFiltered(string word)
    {
        return word.Length < minSize;
    }
}
