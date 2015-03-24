using System;

namespace TicTacToe
{
    public class GameRunner
    {
        private readonly Game game;
        private readonly UserInterface userInterface;

        public GameRunner(Game game, UserInterface userInterface)
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
            else if (game.HasBeenDrawn())
            {
                userInterface.PrintDrawnOutcome();
            }
            else
            {
                throw new Exception("Game ended in neither win nor draw");
            }
        }
    }
}
