namespace Chess.Pieces;

internal sealed class Knight(PieceColor color) : Piece(color)
{
    private protected override IEnumerable<Position> GetMoves(Position currentPosition, Board board)
    {
        throw new NotImplementedException();
    }
}