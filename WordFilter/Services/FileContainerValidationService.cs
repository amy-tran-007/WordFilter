using System.IO.Abstractions;

namespace TextFilter.Services;

internal class FileContainerValidationService(IFileSystem fileSystem) : IFileContainerValidationService
{
    //todo specifiy acceptable file types too
    public Result IsFilePathValid(string? path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return Result.Error("Path must be specified");
        }
        if (!fileSystem.File.Exists(path))
        {
            return Result.Error("File must exist");
        }
        return Result.OK();
    }
}