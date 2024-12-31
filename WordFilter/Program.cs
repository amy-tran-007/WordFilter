﻿using System.IO.Abstractions;
using TextFilter.Commands;
using TextFilter.Containers;
using TextFilter.Services;
using TextFilter.StartUp;

//TODO: dependency injection container
//Read readme file for assumptions and improvements

Console.WriteLine("Please specificy file destination.");
var fileLocation = Console.ReadLine();
var fileSystem = new FileSystem();
IFileContainerValidationService fileContainerValidation = new FileContainerValidationService(fileSystem);
var validPathResult = fileContainerValidation.IsFilePathValid(fileLocation);
if (validPathResult.Failed)
{
    Console.WriteLine($"FilePath not valid: {validPathResult.ErrorMessage}");
    Console.WriteLine($"Press any key to exit");
    var exit = Console.Read;
    Environment.Exit(0);
}

Console.WriteLine("Reading File. Press ctrl+c to cancel");

var token = CancellationTokenSetup.GetCancellationToken();

//doing the work - this would normally be done by IoC
var fileContainer = new CalastoneInterviewContainer(fileLocation!, fileSystem);
var filterCommand = new FilterCommand();
var filteredText = filterCommand.GetFilteredText(fileContainer, token);

Console.WriteLine(filteredText);

