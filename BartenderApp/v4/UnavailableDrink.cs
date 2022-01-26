public class UnavailableDrink : IDrink
{
    private readonly Action<string> outputProvider;
    private readonly string drinkName;

    public UnavailableDrink(Action<string> outputProvider, string drinkName)
    {
        this.outputProvider = outputProvider;
        this.drinkName = drinkName;
    }

    public void Serve()
    {
        outputProvider($"Sorry mate but we don't have {drinkName}.");
    }
}