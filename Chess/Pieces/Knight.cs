namespace Chess.Pieces;

internal sealed class Knight(PieceColor color) : Piece(color)
{
    private protected override IEnumerable<Position> GetMoves(Position currentPosition, Board board)
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

        if (position.IsInbound() is false)
        {
            return null;
        }
        
        var piece = board.GetPiece(position);
        if (piece is not null && piece.Color == Color)
        { 
            return null;
        }

        return position;
    }
}