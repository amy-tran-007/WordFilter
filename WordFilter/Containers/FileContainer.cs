using System.IO.Abstractions;
using TextFilter.TextFilters;

namespace TextFilter.Containers;

internal abstract class FileContainer(string fileLocation, IFileSystem fileSystem) : ITextContainer
{

    public abstract BaseTextFilter TextFilter { get; }
    public virtual IEnumerable<string> TextContent => fileSystem.File.ReadLines(fileLocation);

}
