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

        for (var file = 0; file < 8; file++)
        {
            board[1, file] = new Pawn(PieceType.Pawn, PieceColor.Black);
        }

        for (var file = 0; file < 8; file++)
        {
            board[6, file] = new Pawn(PieceType.Pawn, PieceColor.White);
        }

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