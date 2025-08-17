namespace Chess.Pieces;

internal sealed class Bishop(PieceColor color) : Piece(color)
{
    private protected override IEnumerable<Position> GetMoves(Position currentPosition, Board board)
    {
        throw new NotImplementedException();
    }
}