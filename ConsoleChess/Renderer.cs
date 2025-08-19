using Chess;

namespace ConsoleChess;

internal class Renderer : IRenderer
{
    public void Render(Piece?[,] board)
    {
        Console.Clear();

        for (var rank = 0; rank < 8; rank++)
        {
            Console.WriteLine("  +-----+-----+-----+-----+-----+-----+-----+-----+");

            Console.Write(8 - rank + " |");

            for (var file = 0; file < 8; file++)
            {
                Console.Write(GetPieceSymbol(board[rank, file]) + "|");
            }

            Console.WriteLine();
        }

        Console.WriteLine("  +-----+-----+-----+-----+-----+-----+-----+-----+");
        Console.WriteLine("     A     B     C     D     E     F     G     H");
    }

    private static string GetPieceSymbol(Piece? piece)
    {
        if (piece is null)
        {
            return "  .  ";
        }

        return (piece.Type, piece.Color) switch
        {
            (PieceType.Pawn, PieceColor.White)   => "  P  ",
            (PieceType.Rook, PieceColor.White)   => "  R  ",
            (PieceType.Knight, PieceColor.White) => "  N  ",
            (PieceType.Bishop, PieceColor.White) => "  B  ",
            (PieceType.Queen, PieceColor.White)  => "  Q  ",
            (PieceType.King, PieceColor.White)   => "  K  ",
            (PieceType.Pawn, PieceColor.Black)   => "  p  ",
            (PieceType.Rook, PieceColor.Black)   => "  r  ",
            (PieceType.Knight, PieceColor.Black) => "  n  ",
            (PieceType.Bishop, PieceColor.Black) => "  b  ",
            (PieceType.Queen, PieceColor.Black)  => "  q  ",
            (PieceType.King, PieceColor.Black)   => "  k  ",
            _ => "  .  "
        };
    }
}