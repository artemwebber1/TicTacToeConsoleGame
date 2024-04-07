using TicTacToeConsoleGame.Source.Players.Base;
using TicTacToeConsoleGame.Source.Players;
using TicTacToeConsoleGame.Source.Extensions;

namespace TicTacToeConsoleGame.Source
{
    /// <summary>
    /// Главный класс в игре. Здесь происходит инициализация поля, игроков, а также игровой цикл.
    /// </summary>
    public class TicTacToeGame
    {
        public void Start(int maxPlayersCount)
        {
            GameField field = InitializeField();

            List<Player> players = InitPlayers(maxPlayersCount);

            field.RerenderField();
            while (field.EmptyCells > 0)
            {
                foreach (Player player in players)
                {
                    player.MakeAMoveWithRerender(field);
                    field.EmptyCells--;

                    if (player.IsWinnerOrDraw(field))
                        return;

                    Thread.Sleep(2000);
                }
            }
        }

        private GameField InitializeField()
        {
            Console.WriteLine("Создание поля.");

            // Получение размеров поля
            // Строки
            Console.WriteLine("Введите число строк (не более 10): ");
            int fieldRows = ScanIntInRangeInclusive(0, 10);

            // Столбцы
            Console.WriteLine("Введите число столбцов (не более 20): ");
            int fieldColumns = ScanIntInRangeInclusive(0, 20);

            Console.Clear();

            // Инициализация поля
            GameField field = new GameField(fieldRows, fieldColumns);
            return field;
        }

        private int ScanIntInRangeInclusive(int min, int max)
        {
            while (true)
            {
                try
                {
                    int value = int.Parse(Console.ReadLine());
                    if (value >= min && value <= max)
                        return value;

                    Console.WriteLine($"Число не может быть меньше {min} и больше {max}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Пожалуйста, введите число");
                }
            }
        }

        #region Players initialization

        private List<Player> InitPlayers(int maxPlayersCount)
        {
            int playersCount = ScanPlayersCount(maxPlayersCount);
            Console.Clear();

            List<Player> players = new List<Player>();
            for (int i = 0; i < playersCount; i++)
            {
                Console.Write("Добавить живого игрока или бота? (1/2) >> ");
                string mode = Console.ReadLine();
                Player player = mode switch
                {
                    "1" => new AlivePlayer(),
                    _ => new BotPlayer(),
                };

                players.Add(player);
            }

            return players;
        }

        private int ScanPlayersCount(int maxPlayersCount)
        {
            Console.Write("Введите число игроков: ");
            while (true)
            {
                try
                {
                    int playersCount = int.Parse(Console.ReadLine());

                    if (playersCount > maxPlayersCount || playersCount < 1)
                        Console.WriteLine($"Вы можете добавить не менее 1 и не более {maxPlayersCount} игроков. Попробуйте снова");
                    else
                        return playersCount;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Пожалуйста, введите число");
                }
            }
        }

        #endregion
    }
}
