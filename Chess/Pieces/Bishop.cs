using System.ComponentModel;

namespace Chess.Pieces;

internal sealed class Bishop(PieceType type, PieceColor color) : Piece(type, color)
{
    internal override IEnumerable<Position> GetMoves(Position currentPosition, Board board)
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