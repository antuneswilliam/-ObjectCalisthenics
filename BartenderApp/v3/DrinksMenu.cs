public class DrinksMenu
{
    private readonly Dictionary<string, Action> drinks;
    private readonly Func<string> inputProvider;
    private readonly Action<string> outputProvider;


    public DrinksMenu(Func<string> inputProvider, Action<string> outputProvider)
    {
        this.inputProvider = inputProvider;
        this.outputProvider = outputProvider;

        drinks = new Dictionary<string, Action>
        {
            {"beer", ServeBeer},
            {"juice", ServeJuice},
        };
    }

    public Action GetDrink(string drink)
    {
        return drinks[drink];
    }

    public IEnumerable<string> GetAvailableDrinks()
    {
        return drinks.Keys;
    }

    private void UnavailableDrink(string drink)
    {
        outputProvider($"Sorry mate but we don't do {drink}");
    }

    private void ServeJuice()
    {
        outputProvider("Here you go! Fresh and nice juice.");
    }

    private void ServeBeer()
    {
        outputProvider("Not so fast cowboy. How old are you?");

        if (!int.TryParse(inputProvider(), out var age))
        {
            HandleInvalidAge();
            return;
        }

        HandleBeerAgeCheck(age);
    }

    private void HandleBeerAgeCheck(int age)
    {
        if (age >= 18)
        {
            outputProvider("Here you go! Cold beer.");
            return;
        }

        outputProvider("Sorry but you're notold enough to drink");
    }

    private void HandleInvalidAge()
    {
        outputProvider("Could not parse the age provided");
    }
}