namespace TicTacToe
{
    public interface UserInput
    {
        string GetPlayerType(Mark mark, string[] options);
        int GetUserPosition();
    }
}
