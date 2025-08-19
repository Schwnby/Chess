namespace Chess;

public interface IRenderer
{
    void Render(Piece?[,] board);
}