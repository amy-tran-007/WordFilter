using TextFilter.TextFilters;

namespace TextFilter.Containers
{
    internal interface ITextContainer
    {
        BaseTextFilter TextFilter { get; }
        IEnumerable<string> TextContent { get; }
        bool IsValid();
    }
}
