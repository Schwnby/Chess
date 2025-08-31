namespace Chess.Pieces;

internal sealed class King(PieceType type, PieceColor color) : Piece(type, color)
{
    internal override IEnumerable<Position> GetMoves(Position currentPosition, Board board)
    {
        var validMoves = new List<Position?>
        {
            GetPotentialMove(-1, -1, currentPosition, board),
            GetPotentialMove(-1, 0, currentPosition, board), 
            GetPotentialMove(-1, 1, currentPosition, board),
            GetPotentialMove(0, 1, currentPosition, board),
            GetPotentialMove(1, 1, currentPosition, board),
            GetPotentialMove(1, 0, currentPosition, board),
            GetPotentialMove(1, -1, currentPosition, board),
            GetPotentialMove(0, -1, currentPosition, board),
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