public class BartenderV4 : IBartender
{
    private readonly Func<string> inputProvider;
    private readonly Action<string> outputProvider;
    private readonly DrinksProvider drinksProvider;

    public BartenderV4(Func<string> inputProvider,
        Action<string> outputProvider,
        DrinksProvider drinksProvider)
    {
        this.inputProvider = inputProvider;
        this.outputProvider = outputProvider;
        this.drinksProvider = drinksProvider;
    }

    public void AskForDrink()
    {
        outputProvider($"What drink do you want? ({string.Join(", ", drinksProvider.AvailableDrinks())})");

        var askedDrink = inputProvider() ?? string.Empty;

        var drink = drinksProvider.GetDrink(askedDrink);

        drink.Serve();
    }
}