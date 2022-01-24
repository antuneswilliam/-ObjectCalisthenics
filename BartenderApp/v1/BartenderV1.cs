public class BartenderV1 : IBartender
{
    private readonly Func<string> inputProvider;
    private readonly Action<string> outputProvider;

    public BartenderV1(Func<string> inputProvider, Action<string> outputProvider)
    {
        this.inputProvider = inputProvider;
        this.outputProvider = outputProvider;
    }

    public void AskForDrink()
    {
        outputProvider("What drink do you want? (beer, juice)");

        var drink = inputProvider() ?? string.Empty;

        if (drink.Equals("beer"))
        {
            outputProvider("Not so fast cowboy. How old are you?");

            if (!int.TryParse(inputProvider(), out var age))
            {
                outputProvider("Could not parse the age provided");
            }
            else
            {
                if (age >= 18)
                {
                    outputProvider("Here you go! Cold beer.");
                }
                else
                {
                    outputProvider("Sorry but you're notold enough to drink");
                }
            }
        }
        else if (drink.Equals("juice"))
        {
            outputProvider("Here you go! Fresh and nice juice.");
        }
        else 
        {
            outputProvider($"Sorry mate but we don't do {drink}");
        }
    }
}