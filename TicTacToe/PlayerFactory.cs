namespace TicTacToe
{
    public interface PlayerFactory
    {
        Player Build(Mark playerMark, Mark opponentMark);
    }
}
