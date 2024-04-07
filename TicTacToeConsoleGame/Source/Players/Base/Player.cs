using TicTacToeConsoleGame.Source;

namespace TicTacToeConsoleGame.Source.Players.Base
{
    /// <summary>
    /// Базовый класс для игрока.
    /// </summary>
    public abstract class Player
    {
        protected Player()
        {
            _playerNumber++;
        }

        public string Name { get; protected set; }

        /// <summary>
        /// Символ пользователя.
        /// </summary>
        public char Char { get; protected set; }

        /// <summary>
        /// Победил ли пользователь?
        /// </summary>
        public bool IsWinner { get; private set; }

        /// <summary>
        /// Номер игрока.
        /// </summary>
        protected static int _playerNumber = 0;

        /// <summary>
        /// Занятые символы.
        /// </summary>
        protected static readonly List<char> _pickedChars = new List<char>();

        /// <summary>
        /// Занятые имена.
        /// </summary>
        protected static List<string> _pickedNames = new List<string>();

        /// <summary>
        /// Проверка на победу
        /// </summary>
        /// <param name="field">Игровое поле</param>
        /// <param name="coords">Координаты, введённые игроком</param>
        private void CheckIsWin(char[,] field, Point2D coords)
        {
            if (WinnerChecker.CheckHorizontal(field, Char, coords) ||
                WinnerChecker.CheckVertical(field, Char, coords) ||
                WinnerChecker.CheckDiagonals(field, Char, coords))
                IsWinner = true;
        }

        /// <summary>
        /// Игрок делает ход.
        /// </summary>
        /// <param name="field"></param>
        public void MakeAMove(char[,] field)
        {
            // Читаем координаты, введённые игроком
            Point2D coords = ScanCoords(field);
            // Обновляем поле
            field[coords.Y, coords.X] = Char;
            // Проверяем на победу
            CheckIsWin(field, coords);
        }

        /// <summary>
        /// Получаем координыт игрока. Каждый тип игрока может вводить координаты по-своему.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        protected abstract Point2D ScanCoords(char[,] field);
    }
}