namespace Chess.Pieces;

internal sealed class Rook(PieceColor color) : Piece(color)
{
    private protected override IEnumerable<Position> GetMoves(Position currentPosition, Board board)
    {
       var movesUp = GetStraightMoves(0, 1, currentPosition, board);
       var movesRight = GetStraightMoves(1, 0, currentPosition, board);
       var movesDown = GetStraightMoves(0, -1, currentPosition, board);
       var movesLeft = GetStraightMoves(-1, 0, currentPosition, board);

        return [..movesUp, ..movesDown, ..movesLeft, ..movesRight];
    }

    private List<Position> GetStraightMoves(int rankOffset, int fileOffset, Position position, Board board)
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