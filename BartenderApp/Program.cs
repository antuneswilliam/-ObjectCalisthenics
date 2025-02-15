﻿// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

var bartenderVersions = new Dictionary<string, IBartender>
{
    {"v1", new BartenderV1(Console.ReadLine, Console.WriteLine)},
    
    {"v2", new BartenderV2(Console.ReadLine, Console.WriteLine)},
    
    {"v3", new BartenderV3(Console.ReadLine, Console.WriteLine, 
        new DrinksMenu(Console.ReadLine, Console.WriteLine))},

    {"v4", new BartenderV4(Console.ReadLine, Console.WriteLine, 
        new DrinksProvider(Console.ReadLine, Console.WriteLine))},
};

Console.WriteLine($"Choose Bartender version ({string.Join(", ", bartenderVersions.Keys)})");
var version = Console.ReadLine();

if (!bartenderVersions.Keys.Contains(version))
{
    throw new NotImplementedException($"Sorry, version {version} is not implemented.");
}

while (true)
{
    bartenderVersions[version].AskForDrink();
}