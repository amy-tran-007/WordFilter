using System.IO.Abstractions;
using TextFilter.TextFilters;
using TextFilter.ValueObjects;

namespace TextFilter.Containers;

internal abstract class FileContainer(FileLocation fileLocation, IFileSystem fileSystem) : ITextContainer
{

    public abstract BaseTextFilter TextFilter { get; }
    public virtual IEnumerable<string> TextContent => fileSystem.File.ReadLines(fileLocation);

}
