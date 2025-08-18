namespace Chess.Pieces;

internal sealed class Queen(PieceColor color) : Piece(color)
{
    private protected override IEnumerable<Position> GetMoves(Position currentPosition, Board board)
    {
        return [..GetRookMoves(currentPosition, board), ..GetBishopMoves(currentPosition, board)];
    }

    private List<Position> GetBishopMoves(Position currentPosition, Board board)
    {
        var movesUpLeft = Something(-1, -1, currentPosition, board);
        var movesUpRight = Something(1, -1, currentPosition, board);
        var movesDownLeft = Something(-1, 1, currentPosition, board);
        var movesDownRight = Something(1, 1, currentPosition, board);

        return [..movesUpLeft, ..movesUpRight, ..movesDownLeft, ..movesDownRight];
    }

    private List<Position> GetRookMoves(Position currentPosition, Board board)
    {
        var movesUp = Something(0, 1, currentPosition, board);
        var movesRight = Something(1, 0, currentPosition, board);
        var movesDown = Something(0, -1, currentPosition, board);
        var movesLeft = Something(-1, 0, currentPosition, board);
        
        return [..movesUp, ..movesDown, ..movesLeft, ..movesRight];
    } 
    
    private List<Position> Something(int rankOffset, int fileOffset, Position position, Board board)
    {
        var validMoves = new List<Position>();
        
        while (true)
        {
            position = new Position(position.Rank + rankOffset, position.File + fileOffset);
            if (position.IsInbound() is false)
            {
                break;
            }
            
            var piece = board.GetPiece(position);
            if (piece is null)
            {
                validMoves.Add(position);
                continue;
            }

            if (piece.Color != Color)
            {
                validMoves.Add(position);
            }
            
            break;
        }
        
        return validMoves;
    }
}