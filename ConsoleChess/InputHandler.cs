using System.Text.RegularExpressions;
using Chess;

namespace ConsoleChess;

internal class InputHandler : InputReceiver
{
    private static readonly Regex ValidInputPattern = new("^[a-hA-H][1-8][a-hA-H][1-8]$", RegexOptions.Compiled); // Must be exactly 4 characters: letters from a-h or A-H and digits from 1-8 e.g. e2e4, c6d4

    protected override Move GetRawInput()
    {
        while (true)
        {
            Console.Write("Input your move: ");
            var input = Console.ReadLine();

            if (input is not null && ValidInputPattern.IsMatch(input))
            {
                return GetMove(input);
            }
            
            Console.Write("Invalid Input! ");
        }
    }

    private static Move GetMove(string input)
    {
        var source = GetPosition(input[..2]);
        var target = GetPosition(input[2..]);

        return new Move(source, target);
    }

    private static Position GetPosition(string square)
    {
        var rank = 7 - (square[1] - '1');
        var file = char.ToLower(square[0]) - 'a';

        return new Position(rank, file);
    }
}