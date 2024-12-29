﻿using TextFilter.Commands;
using TextFilter.Containers;

Console.WriteLine("Please specificy file destination");

var fileLocation = Console.ReadLine();
fileLocation = @"C:\Projects\WordFilter\test.txt";
var fileContainer = new CalastoneInterviewContainer(fileLocation!);
var filterCommand = new FilterCommand();
var filteredText = filterCommand.GetFilteredText(fileContainer);
Console.WriteLine(filteredText);