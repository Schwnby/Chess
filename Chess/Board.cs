using Chess.Pieces;

namespace Chess;

internal class Board
{
    private readonly Piece?[,] board = GetStartingBoard();

    public void MovePiece(Move move)
    {
        var piece = board[move.Source.Rank, move.Source.File];
        board[move.Target.Rank, move.Target.File] = piece;
        board[move.Source.Rank, move.Source.File] = null;
        
        piece?.MarkAsMoved();
    }

    public Piece? GetPiece(Position position)
    {
        return board[position.Rank, position.File];
    }
    
    public Piece?[,] GetBoard()
    {
        var boardCopy = new Piece?[8, 8];
        
        for (var rank = 0; rank < 8; rank++)
        {
            for (var file = 0; file < 8; file++)
            {
                boardCopy[rank, file] = board[rank, file];
            }
        }

        return boardCopy;
    }
    
    public bool IsLegalMove(Move move, PieceColor color)
    {
        MovePiece(move.Source, move.Target);
        var kingIsInCheck = IsKingInCheck(color);
        MovePiece(move.Target, move.Source);

        return kingIsInCheck is false;
    }

    private void MovePiece(Position source, Position target)
    {
        var piece = board[source.Rank, source.File];
        board[target.Rank, target.File] = piece;
        board[source.Rank, source.File] = null;
    }

    private bool IsKingInCheck(PieceColor color)
    {
        var opponentColor = color == PieceColor.White ? PieceColor.Black : PieceColor.White;
        
        var kingPosition = GetKingPosition(color);
        var positions = GetPiecePositions(opponentColor);
        
        foreach (var position in positions)
        {
            var piece = GetPiece(position) ?? throw new InvalidOperationException($"No piece found at {position}");
            
            var moves = piece.GetMoves(position, this);
            if (moves.Contains(kingPosition))
            {
                return true;
            }
        }

        return false;
    }

    private Position GetKingPosition(PieceColor color)
    {
        for (var rank = 0; rank < 8; rank++)
        {
            for (var file = 0; file < 8; file++)
            {
                var piece = board[rank, file];
                if (piece is { Type: PieceType.King } && piece.Color == color)
                {
                    return new Position(rank, file);
                }
            }
        }

        throw new InvalidOperationException($"No {color} king found");
    }

    private List<Position> GetPiecePositions(PieceColor color)
    {
        var positions = new List<Position>();
        
        for (var rank = 0; rank < 8; rank++)
        {
            for (var file = 0; file < 8; file++)
            {
                var piece = board[rank, file];
                if (piece is not null && piece.Color == color)
                {
                    positions.Add(new Position(rank, file));
                }
            }
        }

        return positions;
    }

    private static Piece?[,] GetStartingBoard()
    {
        var board = new Piece?[8, 8];
        
        board[0, 0] = new Rook(PieceType.Rook, PieceColor.Black);
        board[0, 1] = new Knight(PieceType.Knight, PieceColor.Black);
        board[0, 2] = new Bishop(PieceType.Bishop, PieceColor.Black);
        board[0, 3] = new Queen(PieceType.Queen, PieceColor.Black);
        board[0, 4] = new King(PieceType.King, PieceColor.Black);
        board[0, 5] = new Bishop(PieceType.Bishop, PieceColor.Black);
        board[0, 6] = new Knight(PieceType.Knight, PieceColor.Black);
        board[0, 7] = new Rook(PieceType.Rook, PieceColor.Black);
        
        board[1, 0] = new Pawn(PieceType.Pawn, PieceColor.Black);
        board[1, 1] = new Pawn(PieceType.Pawn, PieceColor.Black);
        board[1, 2] = new Pawn(PieceType.Pawn, PieceColor.Black);
        board[1, 3] = new Pawn(PieceType.Pawn, PieceColor.Black);
        board[1, 4] = new Pawn(PieceType.Pawn, PieceColor.Black);
        board[1, 5] = new Pawn(PieceType.Pawn, PieceColor.Black);
        board[1, 6] = new Pawn(PieceType.Pawn, PieceColor.Black);
        board[1, 7] = new Pawn(PieceType.Pawn, PieceColor.Black);
        
        board[6, 0] = new Pawn(PieceType.Pawn, PieceColor.White);
        board[6, 1] = new Pawn(PieceType.Pawn, PieceColor.White);
        board[6, 2] = new Pawn(PieceType.Pawn, PieceColor.White);
        board[6, 3] = new Pawn(PieceType.Pawn, PieceColor.White);
        board[6, 4] = new Pawn(PieceType.Pawn, PieceColor.White);
        board[6, 5] = new Pawn(PieceType.Pawn, PieceColor.White);
        board[6, 6] = new Pawn(PieceType.Pawn, PieceColor.White);
        board[6, 7] = new Pawn(PieceType.Pawn, PieceColor.White);
            
        board[7, 0] = new Rook(PieceType.Rook, PieceColor.White);
        board[7, 1] = new Knight(PieceType.Knight, PieceColor.White);
        board[7, 2] = new Bishop(PieceType.Bishop, PieceColor.White);
        board[7, 3] = new Queen(PieceType.Queen, PieceColor.White);
        board[7, 4] = new King(PieceType.King, PieceColor.White);
        board[7, 5] = new Bishop(PieceType.Bishop, PieceColor.White);
        board[7, 6] = new Knight(PieceType.Knight, PieceColor.White);
        board[7, 7] = new Rook(PieceType.Rook, PieceColor.White);
        
        return board;
    }
}