public class BartenderV3 : IBartender
{
    private readonly Func<string> inputProvider;
    private readonly Action<string> outputProvider;
    private readonly DrinksMenu drinksMenu;

    public BartenderV3(Func<string> inputProvider,
        Action<string> outputProvider,
        DrinksMenu drinksMenu)
    {
        this.inputProvider = inputProvider;
        this.outputProvider = outputProvider;
        this.drinksMenu = drinksMenu;
    }

    public void AskForDrink()
    {
        outputProvider($"What drink do you want? ({string.Join(", ", drinksMenu.GetAvailableDrinks())})");

        var drink = inputProvider() ?? string.Empty;

        if (!drinksMenu.GetAvailableDrinks().Contains(drink))
        {
            outputProvider($"Sorry mate but we don't do {drink}");
            return;
        }

        var drinkToDo = drinksMenu.GetDrink(drink);
        drinkToDo();
    }
}