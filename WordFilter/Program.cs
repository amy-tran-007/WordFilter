using System.IO.Abstractions;
using TextFilter.Commands;
using TextFilter.Containers;
using TextFilter.Services;

Console.WriteLine("Please specificy file destination");
var fileLocation = Console.ReadLine();

IFileContainerValidationService fileContainerValidation = new FileContainerValidationService(new FileSystem());
var validPathResult = fileContainerValidation.IsFilePathValid(fileLocation);
if (validPathResult.Failed)
{
    Console.WriteLine($"FilePath not valid: {validPathResult.ErrorMessage}");
    Console.WriteLine($"Press any key to exit");
    var exit = Console.ReadLine;
    Environment.Exit(0);
}

var fileContainer = new CalastoneInterviewContainer(fileLocation!, new FileSystem());
var filterCommand = new FilterCommand();
var filteredText = filterCommand.GetFilteredText(fileContainer);
Console.WriteLine(filteredText);