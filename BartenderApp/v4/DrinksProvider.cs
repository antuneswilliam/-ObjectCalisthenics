public class DrinksProvider
{
    private readonly Dictionary<string, IDrink> drinksMenu;
    private readonly Func<string> inputProvider;
    private readonly Action<string> outputProvider;


    public DrinksProvider(Func<string> inputProvider, Action<string> outputProvider)
    {
        this.inputProvider = inputProvider;
        this.outputProvider = outputProvider;

        drinksMenu = new Dictionary<string, IDrink>
        {
            {"beer", new Beer(inputProvider, outputProvider)},
            {"juice", new Juice(outputProvider)},
        };
    }

    public IDrink GetDrink(string drink)
    {
        if (!AvailableDrinks().Contains(drink))
            return new UnavailableDrink(outputProvider);

        return drinksMenu[drink];
    }

    public IEnumerable<string> AvailableDrinks()
    {
        return drinksMenu.Keys;
    }
}