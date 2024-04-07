using TicTacToeConsoleGame.Source;

namespace TicTacToeConsoleGame
{
    public static class Program
    {
        public static void Main()
        {
            // Инициализация игры
            TicTacToeGame game = new TicTacToeGame();
            // Начало  игры
            game.Start(maxPlayersCount: 10);
        }
    }
}
