namespace TicTacToe
{
    public class GameRunner
    {
        private readonly Game game;
        private readonly Display userInterface;

        public GameRunner(Game game, Display userInterface)
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
            PrintBoard();
            while (GameIsInPlay() && CurrentPlayerIsReady())
            {
                PrintNextPlayerToGo();
                PlayTurn();
                PrintBoard();
            }
        }

        bool CurrentPlayerIsReady()
        {
            return game.CurrentPlayerReady();
        }

        private void PlayTurn()
        {
            game.PlayTurn();
        }

        private bool GameIsInPlay()
        {
            return !game.IsGameOver();
        }

        void PrintBoard()
        {
            userInterface.PrintBoard(game.Board);
        }

        private void PrintGameMessages()
        {
            PrintBoard();
            PrintNextPlayerToGo();
        }

        private void PrintOutcome()
        {
            if (game.HasBeenWon())
            {
                userInterface.PrintWinOutcome(game.WinningMark());
            }
            else if (game.HasBeenDrawn())
            {
                userInterface.PrintDrawnOutcome();
            }
            else
            {
                PrintNextPlayerToGo();
            }
        }

        void PrintNextPlayerToGo()
        {
            userInterface.PrintNextPlayer(game.CurrentPlayerMark);
        }
    }
}
