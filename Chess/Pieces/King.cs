namespace Chess.Pieces;

internal sealed class King(PieceColor color) : Piece(color)
{
    private protected override IEnumerable<Position> GetMoves(Position currentPosition, Board board)
    {
        throw new NotImplementedException();
    }
}