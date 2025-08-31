namespace Chess.Pieces;

internal sealed class Queen(PieceType type, PieceColor color) : Piece(type, color)
{
    internal override IEnumerable<Position> GetMoves(Position currentPosition, Board board)
    {
        return [..GetStraightMoves(currentPosition, board), ..GetDiagonalMoves(currentPosition, board)];
    }

    private List<Position> GetDiagonalMoves(Position currentPosition, Board board)
    {
        var movesUpLeft = GetLinearMoves(-1, -1, currentPosition, board);
        var movesUpRight = GetLinearMoves(1, -1, currentPosition, board);
        var movesDownLeft = GetLinearMoves(-1, 1, currentPosition, board);
        var movesDownRight = GetLinearMoves(1, 1, currentPosition, board);

        return [..movesUpLeft, ..movesUpRight, ..movesDownLeft, ..movesDownRight];
    }

    private List<Position> GetStraightMoves(Position currentPosition, Board board)
    {
        var movesUp = GetLinearMoves(0, 1, currentPosition, board);
        var movesRight = GetLinearMoves(1, 0, currentPosition, board);
        var movesDown = GetLinearMoves(0, -1, currentPosition, board);
        var movesLeft = GetLinearMoves(-1, 0, currentPosition, board);
        
        return [..movesUp, ..movesDown, ..movesLeft, ..movesRight];
    } 
    
    private List<Position> GetLinearMoves(int rankOffset, int fileOffset, Position position, Board board)
    {
        var validMoves = new List<Position>();
        
        while (true)
        {
            position = new Position(position.Rank + rankOffset, position.File + fileOffset);
            if (CanMoveTo(position, board))
            {
                validMoves.Add(position);
            }

            if (position.IsInbound() is false || board.GetPiece(position) is not null)
            {
                break;
            }
        }
        
        return validMoves;
    }
}