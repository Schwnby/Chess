namespace Chess.Pieces;

internal sealed class Bishop(PieceColor color) : Piece(color)
{
    private protected override IEnumerable<Position> GetMoves(Position currentPosition, Board board)
    {
        var movesUpLeft = GetDiagonalMoves(-1, -1, currentPosition, board);
        var movesUpRight = GetDiagonalMoves(1, -1, currentPosition, board);
        var movesDownLeft = GetDiagonalMoves(-1, 1, currentPosition, board);
        var movesDownRight = GetDiagonalMoves(1, 1, currentPosition, board);

        return [..movesUpLeft, ..movesUpRight, ..movesDownLeft, ..movesDownRight];
    }

    private List<Position> GetDiagonalMoves(int rankOffset, int fileOffset, Position position, Board board)
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