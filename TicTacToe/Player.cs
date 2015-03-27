namespace TicTacToe
{
    public interface Player
    {
        Move GetMove(Game game);
        bool Ready();
        Mark Mark { get; }
    }
}
