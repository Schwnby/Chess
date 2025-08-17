using Chess;

namespace ConsoleChess;

internal class Renderer : IRenderer
{
    private readonly string[,] board = new[,]
    {
        { "  r  ","  n  ","  b  ","  q  ","  k  ","  b  ","  n  ","  r  " },
        { "  p  ","  p  ","  p  ","  p  ","  p  ","  p  ","  p  ","  p  " },
        { "  .  ","  .  ","  .  ","  .  ","  .  ","  .  ","  .  ","  .  " },
        { "  .  ","  .  ","  .  ","  .  ","  .  ","  .  ","  .  ","  .  " },
        { "  .  ","  .  ","  .  ","  .  ","  .  ","  .  ","  .  ","  .  " },
        { "  .  ","  .  ","  .  ","  .  ","  .  ","  .  ","  .  ","  .  " },
        { "  P  ","  P  ","  P  ","  P  ","  P  ","  P  ","  P  ","  P  " },
        { "  R  ","  N  ","  B  ","  Q  ","  K  ","  B  ","  N  ","  R  " }
    };

    public void Render()
    {
        Console.Clear();

        for (var rank = 0; rank < 8; rank++)
        {
            Console.WriteLine("  +-----+-----+-----+-----+-----+-----+-----+-----+");

            Console.Write(8 - rank + " |");

            for (var file = 0; file < 8; file++)
            {
                Console.Write(board[rank, file] + "|");
            }

            Console.WriteLine();
        }

        Console.WriteLine("  +-----+-----+-----+-----+-----+-----+-----+-----+");
        Console.WriteLine("     A     B     C     D     E     F     G     H");
    }

    public void Render(Move move)
    {
        UpdateBoard(move);
        Render();
    }

    private void UpdateBoard(Move move)
    {
        var piece = board[move.Source.Rank, move.Source.File];

        board[move.Target.Rank, move.Target.File] = piece;
        board[move.Source.Rank, move.Source.File] = "  .  ";
    }
}