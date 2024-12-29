using TextFilter.TextFilters;

namespace TextFilter.Containers
{
    internal class FileContainer(string fileLocation) : ITextContainer
    {
        private string FileLocation { get; init; } = default!;
        public BaseTextFilter TextFilter => new MiddleVowelFilter()
                                        .SetNextFilter(new LengthFilter())
                                        .SetNextFilter(new RemoveTFilter());

        public IEnumerable<string> TextContent => File.ReadLines(fileLocation);

    }
}
