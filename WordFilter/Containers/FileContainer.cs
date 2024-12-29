using TextFilter.TextFilters;

namespace TextFilter.Containers
{
    internal class FileContainer(string fileLocation) : ITextContainer
    {

        private string FileLocation { get; init; } = default!;
        private const int MINIMUM_WORD_LENGTH = 3;
        public BaseTextFilter TextFilter
        {
            get
            {
                var filter = new MiddleVowelFilter();
                filter.SetNextFilter(new LengthFilter(MINIMUM_WORD_LENGTH))
                .SetNextFilter(new RemoveTFilter());
                return filter;
            }
        }

        public IEnumerable<string> TextContent => File.ReadLines(fileLocation);

    }
}
