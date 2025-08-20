namespace Chess;

public class Game(IRenderer renderer, InputReceiver inputReceiver)
{
    private readonly Board board = new();

    public void TestFeatures()
    {
        while (true)
        {
            renderer.Render(board.GetBoard());
            var move = inputReceiver.GetInput();
            
            var piece = board.GetPiece(move.Source);
            if (piece is null)
            {
                continue;
            }
            
            var legalMoves= piece.GetLegalMoves(move.Source, board);
            if (legalMoves.Contains(move.Target))
            {
                board.MovePiece(move);
            }
        }
    }
}