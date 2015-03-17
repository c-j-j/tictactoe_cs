namespace TicTacToe
{
    public class GameDriver
    {
        private readonly Game game;
        private readonly UserInterface userInterface;

        public GameDriver(Game game, UserInterface userInterface)
        {
            this.userInterface = userInterface;
            this.game = game;
        }

        public void Run()
        {
            PlayGame();
            PrintOutcome();
        }

        private void PlayGame()
        {
            while (GameIsInPlay())
            {
                PrintGameMessages();
                PlayTurn();
            }
        }

        private void PlayTurn()
        {
            game.PlayTurn();
        }

        private bool GameIsInPlay()
        {
            return !game.IsGameOver();
        }

        private void PrintGameMessages()
        {
            userInterface.PrintBoard(game.Board);
            userInterface.PrintNextPlayer(game.CurrentPlayerMark);
        }

        private void PrintOutcome()
        {
            if (game.HasBeenWon())
            {
                userInterface.PrintWinOutcome(game.WinningMark());
            }
            else
            {
                userInterface.PrintDrawnOutcome();
            }
        }
    }
}
