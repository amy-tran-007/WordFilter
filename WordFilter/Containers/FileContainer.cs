using TextFilter.TextFilters;

namespace TextFilter.Containers
{
    internal abstract class FileContainer(string fileLocation) : ITextContainer
    {
        public abstract BaseTextFilter TextFilter { get; }
        public IEnumerable<string> TextContent => File.ReadLines(fileLocation);

    }
}
