using CarDriver;

internal class Program
{
    private static void Main(string[] args)
    {
        IViewEngine viewEngine = new ConsolePrinter();
        var gameEngine = new GameEngine(viewEngine);
        gameEngine.Play();
    }
}