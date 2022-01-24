// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

var drinksMenu = new DrinksMenu(Console.ReadLine, Console.WriteLine);

var bartenderVersions = new Dictionary<string, IBartender>
{
    {"v1", new BartenderV1(Console.ReadLine, Console.WriteLine)},
    {"v2", new BartenderV2(Console.ReadLine, Console.WriteLine)},
    {"v3", new BartenderV3(Console.ReadLine, Console.WriteLine, drinksMenu)},
};

Console.WriteLine("Choose Bartender version (v1, v2, v3)");
var version = Console.ReadLine();

if (!bartenderVersions.Keys.Contains(version))
{
    throw new NotImplementedException($"Sorry, version {version} is not implemented.");
}

while (true)
{
    bartenderVersions[version].AskForDrink();
}