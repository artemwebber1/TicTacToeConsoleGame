using TicTacToeConsoleGame.Source;
using TicTacToeConsoleGame.Source.Players.Base;

namespace TicTacToeConsoleGame.Source.Players
{
    public sealed class AlivePlayer : Player
    {
        public AlivePlayer() : base()
        {
            // Получаем имя игрока
            Name = ScanName();

            // Получаем символ игрока
            Char = ScanChar();
        }

        private char ScanChar()
        {
            Console.Write($"{Name}, введите символ: ");

            // Просим ввести уникальный символ
            while (true)
            {
                try
                {
                    char chr = char.Parse(Console.ReadLine());

                    if (!_pickedChars.Contains(chr))
                    {
                        // Добавляем символ в общий список в целях избежания повторов
                        _pickedChars.Add(chr);
                        return chr;
                    }
                    else
                    {
                        Console.WriteLine("Этот символ уже занят. Попробуйте другой");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Пожалуйста, введите один символ.");
                }
            }
        }

        private string ScanName()
        {
            Console.Write($"Игрок №{_playerNumber}, введите имя: ");
            string name = Console.ReadLine();

            // Не даём пользователю продолжить, пока не введёт уникальное имя.
            while (_pickedNames.Contains(name))
            {
                Console.WriteLine("Это имя уже занято. Попробуйте другое");
                name = Console.ReadLine();
            }

            // Добавляем имя в общий список, чтобы не было повторов.
            _pickedNames.Add(name);

            return name;
        }

        /// <summary>
        /// У живых игроков ввод координат осуществляется с клавиатуры.
        /// </summary>
        /// <param name="field">Игровое поле</param>
        protected override Point2D ScanCoords(char[,] field)
        {
            Console.WriteLine($"{Name} делает ход ('{Char}'): ");

            int maxX = field.GetLength(1) - 1;
            int maxY = field.GetLength(0) - 1;

            while (true)
            {
                try
                {
                    // Отнимаем единицу, чтобы с координатами пользователя можно было работать как с индексами
                    int row = int.Parse(Console.ReadLine()) - 1;
                    int column = int.Parse(Console.ReadLine()) - 1;

                    if (row <= maxY && row >= 0 &&
                        column <= maxX && column >= 0 &&
                        field[row, column] == ' ')
                        return new Point2D(column, row);

                    Console.WriteLine("Вы не можете сделать ход сюда. Попробуйте сделать ход в другое место");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Пожалуйста, введите число");
                }
            }
        }
    }
}
