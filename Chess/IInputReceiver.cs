namespace Chess;

public abstract class InputReceiver
{
    protected abstract Move GetRawInput();

    internal Move GetInput()
    {
        while (true)
        {
            var move = GetRawInput();

            if (move.IsValid())
            {
                return move;
            }
        }
    }
}