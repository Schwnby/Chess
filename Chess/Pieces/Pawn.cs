namespace Chess.Pieces;

internal sealed class Pawn(PieceColor color) : Piece(color)
{
    private protected override IEnumerable<Position> GetMoves(Position currentPosition, Board board)
    {
        var direction = Color == PieceColor.White ? -1 : 1;

        var validForwardPositions = GetForwardPositions(currentPosition, board, direction);
        var validCapturePositions = GetCapturePositions(currentPosition, board, direction);
        
        return [..validForwardPositions, ..validCapturePositions];
    }
    
    private List<Position> GetForwardPositions(Position currentPosition, Board board, int direction)
    {
        var validPositions = new List<Position>();

        var oneRankOffset = currentPosition with { Rank = currentPosition.Rank + direction };
        if (oneRankOffset.IsInbound() && board.GetPiece(oneRankOffset) == null)
        {
            validPositions.Add(oneRankOffset);
            
            var twoRankOffset = currentPosition with { Rank = currentPosition.Rank + direction * 2 };
            if (HasMoved is false && board.GetPiece(twoRankOffset) == null)
            {
                validPositions.Add(twoRankOffset);
            }
        }
        
        return validPositions;
    }
    
    private List<Position> GetCapturePositions(Position currentPosition, Board board, int direction)
    {
        var capturePositions = new List<Position>();

        var leftCapture = new Position(currentPosition.Rank + direction, currentPosition.File - 1);
        if (CanCapture(leftCapture, board))
        {
            capturePositions.Add(leftCapture);
        }

        var rightCapture = new Position(currentPosition.Rank + direction, currentPosition.File + 1);
        if (CanCapture(rightCapture, board))
        {
            capturePositions.Add(rightCapture);
        }

        return capturePositions;
    }

    private bool CanCapture(Position offsetPosition, Board board)
    {
        if (offsetPosition.IsInbound() is false)
        {
            return false;
        }

        var piece = board.GetPiece(offsetPosition);
        
        return piece != null && piece.Color != Color;
    }
}