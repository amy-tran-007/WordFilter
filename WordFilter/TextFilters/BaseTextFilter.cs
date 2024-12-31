using TextFilter.Services;

namespace TextFilter.TextFilters;

internal abstract class BaseTextFilter
{
    protected BaseTextFilter NextFilter = default!;

    //TODO: dependency violation here but for code clarity and over engineering have ignored
    protected ITextEditService TextEditService = new RegExTextEditService();

    public BaseTextFilter SetNextFilter(BaseTextFilter nextFilter)
    {
        NextFilter = nextFilter;
        return this.NextFilter;
    }

    protected abstract bool ShouldWordBeFiltered(string word);

    public virtual string ApplyFilter(string line)
    {
        var removeWords = new HashSet<string>();
        if (string.IsNullOrWhiteSpace(line))
        {
            return string.Empty;
        }

        var words = TextEditService.SplitSentenceIntoWords(line);
        foreach (var word in words)
        {
            if (ShouldWordBeFiltered(word) && string.IsNullOrWhiteSpace(word) == false)
            {
                removeWords.Add(word);
            }
        }

        var filteredText = TextEditService.RemoveWord(line, removeWords);

        if (NextFilter != null)
        {
            return $"{NextFilter.ApplyFilter(filteredText)}";
        }
        return filteredText;
    }
}
