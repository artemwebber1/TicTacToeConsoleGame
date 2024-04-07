using TicTacToeConsoleGame.Source.Players.Base;

namespace TicTacToeConsoleGame.Source.Extensions
{
    public static class PlayerExtensions
    {
        /// <summary>
        /// Победил ли игрок игрок или ничья?
        /// </summary>
        /// <param name="player">Какой игрок сделал ход?</param>
        /// <param name="field">Игровое поле</param>
        /// <returns></returns>
        public static bool IsWinnerOrDraw(this Player player, GameField field)
        {
            if (player.IsWinner)
            {
                Console.WriteLine($"{player.Name}('{player.Char}') победил!");
                return true;
            }
            else if (field.EmptyCells == 0)
            {
                Console.WriteLine("Ничья");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Игрок делает ход и поле перерисовывается.
        /// </summary>
        /// <param name="player">Какой игрок сделал ход?</param>
        /// <param name="field">Игровое поле</param>
        public static void MakeAMoveWithRerender(this Player player, GameField field)
        {
            player.MakeAMove(field.Field);
            field.RerenderField();
        }
    }
}
