using System.IO.Abstractions;
using TextFilter.Commands;
using TextFilter.Containers;

//Console.WriteLine("Please specificy file destination");

//var fileLocation = Console.ReadLine();
var fileLocation = @"C:\Projects\WordFilter\test.txt";
var fileContainer = new CalastoneInterviewContainer(fileLocation!, new FileSystem());
var filterCommand = new FilterCommand();
var filteredText = filterCommand.GetFilteredText(fileContainer);
Console.WriteLine(filteredText);