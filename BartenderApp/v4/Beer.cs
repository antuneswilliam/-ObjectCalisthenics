public class Beer : IDrink
{
    private readonly Func<string> inputProvider;
    private readonly Action<string> outputProvider;

    public Beer(Func<string> inputProvider, Action<string> outputProvider)
    {
        this.inputProvider = inputProvider;
        this.outputProvider = outputProvider;
    }

    public void Serve()
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

        outputProvider("Sorry but you're not old enough to drink");
    }

    private void HandleInvalidAge()
    {
        outputProvider("Could not parse the age provided");
    }
}