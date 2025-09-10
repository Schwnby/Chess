namespace Chess;

public class Game(IRenderer renderer, InputReceiver inputReceiver)
{
    private readonly Board board = new();
    private PieceColor colorToMove = PieceColor.White;

    public void TestFeatures()
    {
        while (true)
        {
            renderer.Render(board.GetBoard());
            var move = inputReceiver.GetInput();

            if (TryMakeMove(move))
            {
                FlipColorToMove();
            }
        }
    }

    private bool TryMakeMove(Move move)
    {
        var piece = board.GetPiece(move.Source);
        if (piece is null || piece.Color != colorToMove)
        {
            return false;
        }
            
        var legalMoves= piece.GetLegalMoves(move.Source, board, colorToMove);
        if (legalMoves.Contains(move.Target) is false)
        {
            return false;
        }
        
        board.MovePiece(move);
        return true;
    }

    private void FlipColorToMove()
    {
        colorToMove = 1 - colorToMove;
    }
}