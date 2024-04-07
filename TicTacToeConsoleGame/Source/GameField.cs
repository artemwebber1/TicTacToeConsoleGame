namespace TicTacToeConsoleGame.Source
{
    /// <summary>
    /// Игровое поле.
    /// </summary>
    public class GameField
    {
        public GameField(int rows, int columns)
        {
            Field = new char[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    Field[i, j] = ' ';
            }
            EmptyCells = rows * columns;
        }

        /// <summary>
        /// Игровое поле, представленное как двумерный массив символов.
        /// </summary>
        public char[,] Field { get; private set; }

        /// <summary>
        /// Количество пустых клеток на поле.
        /// </summary>
        public int EmptyCells { get; set; }

        /// <summary>
        /// Рисует поле со всеми нанесёнными на него символами.
        /// </summary>
        public void RenderField()
        {
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                    Console.Write(" (" + Field[i, j] + ") ");

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Очищает консоль и заново рисует поле.
        /// </summary>
        public void RerenderField()
        {
            Console.Clear();
            RenderField();
        }
    }
}