public class UnavailableDrink : IDrink
{
    private readonly Action<string> outputProvider;

    public UnavailableDrink(Action<string> outputProvider)
    {
        this.outputProvider = outputProvider;
    }

    public void Serve()
    {
        outputProvider($"Sorry mate but we don't do this one");
    }
}