
using TextFilter.Commands;
using TextFilter.Containers;

Console.WriteLine("Please specificy file destination");

var fileLocation = Console.ReadLine();

var fileContainer = new FileContainer(fileLocation!);
var filterCommand = new FilterCommand();
var filteredText = filterCommand.GetFilteredText(fileContainer);
Console.WriteLine(filteredText);