using System.IO.Abstractions;
using TextFilter.TextFilters;
using TextFilter.ValueObjects;

namespace TextFilter.Containers;

internal class CalastoneInterviewContainer(FileLocation fileLocation, IFileSystem fileSystem) : FileContainer(fileLocation, fileSystem)
{

    protected const int MINIMUM_WORD_LENGTH = 3;
    private const char FILTER_BY_CHAR = 't';
    public override BaseTextFilter TextFilter
    {
        get
        {
            var filter = new MiddleVowelFilter();
            filter.SetNextFilter(new MinLengthFilter(MINIMUM_WORD_LENGTH))
            .SetNextFilter(new RemoveCharacterFilter(FILTER_BY_CHAR));
            return filter;
        }
    }

}
