namespace Chess.Pieces;

internal sealed class Knight(PieceType type, PieceColor color) : Piece(type, color)
{
    internal override IEnumerable<Position> GetMoves(Position currentPosition, Board board)
    {
        var validMoves = new List<Position?>
        {
            GetPotentialMove(1, 2, currentPosition, board),
            GetPotentialMove(2, 1, currentPosition, board),
            GetPotentialMove(2, -1, currentPosition, board),
            GetPotentialMove(1, -2, currentPosition, board),
            GetPotentialMove(-1, 2, currentPosition, board),
            GetPotentialMove(-2, 1, currentPosition, board),
            GetPotentialMove(-2, -1, currentPosition, board),
            GetPotentialMove(-1, -2, currentPosition, board)
        };

        return validMoves.OfType<Position>();
    }
    
    private Position? GetPotentialMove(int rankOffset, int fileOffset, Position position, Board board)
    {
        position = new Position(position.Rank + rankOffset, position.File + fileOffset);
        if (CanMoveTo(position, board))
        {
            return position;
        }

        return null;
    }
}