using TextFilter.TextFilters;

namespace TextFilter.Containers
{
    internal class FileContainer(string fileLocation) : ITextContainer
    {



        private string FileLocation { get; init; } = default!;
        public BaseTextFilter TextFilter
        {
            get
            {
                var filter = new MiddleVowelFilter();
                filter.SetNextFilter(new LengthFilter())
                .SetNextFilter(new RemoveTFilter());
                return filter;
            }
        }

        public IEnumerable<string> TextContent => File.ReadLines(fileLocation);

    }
}
