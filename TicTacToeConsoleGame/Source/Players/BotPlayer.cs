using TicTacToeConsoleGame.Source;
using TicTacToeConsoleGame.Source.Players.Base;

namespace TicTacToeConsoleGame.Source.Players
{
    public sealed class BotPlayer : Player
    {
        public BotPlayer() : base()
        {
            // Достаём для бота символ из доступных
            int i = 0;
            Char = _aiAviableChars[i];
            while (_pickedChars.Contains(Char))
            {
                i++;
                Char = _aiAviableChars[i];
            }
            _pickedChars.Add(Char);

            // Задаём имя боту
            Name = "Bot" + _playerNumber;
            _pickedNames.Add(Name);
        }

        /// <summary>
        /// Символы, из которых бот будет выбирать свой.
        /// </summary>
        private static readonly List<char> _aiAviableChars = new List<char>
        {
            '?',
            '@',
            '/',
            '#',
            '%',
            '&',
            '$',
            '0',
            'X',
            'O',
        };

        /// <summary>
        /// У ботов ввод координат осуществляется на основе рандома.
        /// </summary>
        /// <param name="field">Игровое поле</param>
        /// <returns></returns>
        protected override Point2D ScanCoords(char[,] field)
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(field.GetLength(1));
                int y = random.Next(field.GetLength(0));

                if (field[y, x] == ' ')
                    return new Point2D(x, y);
            }
        }
    }
}
