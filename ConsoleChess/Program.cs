using Chess;

namespace ConsoleChess;

internal static class Program
{
    private static void Main()
    {
        var game = new Game(new Renderer(), new InputReciever());
        game.TestFeatures();
    }
}