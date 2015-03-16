namespace TicTacToe
{
    public interface Player
    {
        Move GetMove(Game game);

        Mark Mark { get; }
    }
}
