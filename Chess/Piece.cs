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
    
    internal void MarkAsMoved()
    {
        HasMoved = true;
    }
}