namespace TextFilter.Services;

internal interface IFileContainerValidationService
{
    Result IsFilePathValid(string? filepath);
}