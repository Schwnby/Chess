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
        
        board[0, 0] = new Rook(PieceColor.Black);
        board[0, 1] = new Knight(PieceColor.Black);
        board[0, 2] = new Bishop(PieceColor.Black);
        board[0, 3] = new Queen(PieceColor.Black);
        board[0, 4] = new King(PieceColor.Black);
        board[0, 5] = new Bishop(PieceColor.Black);
        board[0, 6] = new Knight(PieceColor.Black);
        board[0, 7] = new Rook(PieceColor.Black);

        for (var file = 0; file < 8; file++)
        {
            board[1, file] = new Pawn(PieceColor.Black);
        }

        for (var file = 0; file < 8; file++)
        {
            board[6, file] = new Pawn(PieceColor.White);
        }

        board[7, 0] = new Rook(PieceColor.White);
        board[7, 1] = new Knight(PieceColor.White);
        board[7, 2] = new Bishop(PieceColor.White);
        board[7, 3] = new Queen(PieceColor.White);
        board[7, 4] = new King(PieceColor.White);
        board[7, 5] = new Bishop(PieceColor.White);
        board[7, 6] = new Knight(PieceColor.White);
        board[7, 7] = new Rook(PieceColor.White);
        
        return board;
    }
}