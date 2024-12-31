namespace TextFilter.Services;

internal interface IFileLocationValidator
{
    Result IsFilePathValid(string? filepath);
}