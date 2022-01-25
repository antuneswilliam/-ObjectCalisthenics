public class Juice : IDrink
{
    private readonly Action<string> outputProvider;

    public Juice(Action<string> outputProvider)
    {
        this.outputProvider = outputProvider;
    }

    public void Serve()
    {
        outputProvider("Here you go! Fresh and nice juice.");
    }
}