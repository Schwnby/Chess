namespace Chess;

public readonly record struct Position(int Rank, int File);

public readonly record struct Move(Position Source, Position Target);

internal static class ExtensionMethods
{
    public static bool IsInbound(this Position position)
    {
        return position.Rank is >= 0 and <= 7 && position.File is >= 0 and <= 7;
    }
    
    public static bool IsInbound(this Move move)
    {
        return move.Source.IsInbound() && move.Target.IsInbound();
    }
}