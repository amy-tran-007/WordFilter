namespace TextFilter.TextFilters;

internal class MinLengthFilter(int minSize) : BaseTextFilter
{
    protected override bool ShouldWordBeFiltered(string word)
    {
        return word.Length < minSize;
    }
}
