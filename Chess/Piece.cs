namespace Chess;

public abstract class Piece(PieceType type, PieceColor color)
{
    public PieceType Type { get; } = type;
    public  PieceColor Color { get; } = color;
    protected bool HasMoved { get; private set; }

    private protected abstract IEnumerable<Position> GetMoves(Position currentPosition, Board board);

    internal IEnumerable<Position> GetLegalMoves(Position currentPosition, Board board)
    {
        return GetMoves(currentPosition, board);
    }

    private protected virtual bool CanMoveTo(Position position, Board board)
    {
        if (position.IsInbound() is false)
        {
            return false;
        }
        
        var piece = board.GetPiece(position);
        
        return piece is null || piece.Color != Color;
    }
    
    internal void MarkAsMoved()
    {
        HasMoved = true;
    }
}