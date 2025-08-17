namespace Chess.Pieces;

internal sealed class Pawn(PieceColor color) : Piece(color)
{
    private protected override IEnumerable<Position> GetMoves(Position currentPosition, Board board)
    {
        var direction = Color == PieceColor.White ? -1 : 1;

        var forwardMoves = GetForwardMoves(currentPosition, board, direction);
        var captureMoves = GetCaptureMoves(currentPosition, board, direction);
        
        return [..forwardMoves, ..captureMoves];
    }
    
    private List<Position> GetForwardMoves(Position currentPosition, Board board, int direction)
    {
        var validMoves = new List<Position>();

        var oneRankOffset = currentPosition with { Rank = currentPosition.Rank + direction };
        if (oneRankOffset.IsInbound() && board.GetPiece(oneRankOffset) == null)
        {
            validMoves.Add(oneRankOffset);
            
            var twoRankOffset = currentPosition with { Rank = currentPosition.Rank + direction * 2 };
            if (HasMoved is false && board.GetPiece(twoRankOffset) == null)
            {
                validMoves.Add(twoRankOffset);
            }
        }
        
        return validMoves;
    }
    
    private List<Position> GetCaptureMoves(Position currentPosition, Board board, int direction)
    {
        var validMoves = new List<Position>();

        var leftCapture = new Position(currentPosition.Rank + direction, currentPosition.File - 1);
        if (CanCapture(leftCapture, board))
        {
            validMoves.Add(leftCapture);
        }

        var rightCapture = new Position(currentPosition.Rank + direction, currentPosition.File + 1);
        if (CanCapture(rightCapture, board))
        {
            validMoves.Add(rightCapture);
        }

        return validMoves;
    }

    private bool CanCapture(Position position, Board board)
    {
        if (position.IsInbound() is false)
        {
            return false;
        }

        var piece = board.GetPiece(position);
        
        return piece != null && piece.Color != Color;
    }
}