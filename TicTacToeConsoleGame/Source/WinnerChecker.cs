namespace TicTacToeConsoleGame.Source
{
    /// <summary>
    /// Проверка каждого хода на победный.
    /// </summary>
    static class WinnerChecker
    {
        /// <summary>
        /// Проверка победного хода по горизонтали.
        /// </summary>
        public static bool CheckHorizontal(char[,] field, char side, Point2D coords)
        {
            int count = 0;

            int xMax = field.GetLength(1) - 1;

            // Math.Clamp() нужны для того, чтобы не выйти за границу массива
            int start = Math.Clamp(coords.X - 2, 0, xMax);
            int end = Math.Clamp(coords.X + 2, 0, xMax);

            for (int x = start; x < end; x++)
            {
                int nextX = Math.Clamp(x + 1, 1, field.GetLength(1) - 1);

                // Если текущий элемент и следующий равны нужному нам символу, увеличиваем счётчик на единицу.
                if (field[coords.Y, x] == side && field[coords.Y, nextX] == side)
                {
                    count++;
                    // Если таких совпадений два и более, возвращаем true, т.к. ход победный
                    if (count >= 2)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Проверка победного хода по вертикали.
        /// </summary>
        public static bool CheckVertical(char[,] field, char side, Point2D coords)
        {
            int count = 0;

            int yMax = field.GetLength(0) - 1;

            int start = Math.Clamp(coords.Y - 2, 0, yMax);
            int end = Math.Clamp(coords.Y + 2, 2, yMax);

            // Проверка по вертикали аналогична проверке по горизонтали (см. выше в методе CheckHorizontal)
            for (int y = start; y < end; y++)
            {
                int nextY = Math.Clamp(y + 1, 1, field.GetLength(0) - 1);

                if (field[y, coords.X] == side && field[nextY, coords.X] == side)
                {
                    count++;
                    if (count >= 2)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Проверка победного хода по двум диагоналям (сверху вниз, слева направо и снизу вверх, слева направо).
        /// </summary>
        public static bool CheckDiagonals(char[,] field, char side, Point2D coords)
        {
            // Максимальное значение по X
            int xMax = field.GetLength(1) - 1;

            // Максимальное значение по Y
            int yMax = field.GetLength(0) - 1;

            // Проверка первой диагонали (сверху вниз, слева направо)
            bool firstDiagonalCheckResult = CheckDiagonal(coords, xMax, yMax, side, field, false);

            // Проверка второй диагонали (снизу вверх, слева направо)
            bool secondDiagonalCheckResult = CheckDiagonal(coords, xMax, yMax, side, field, true);

            return firstDiagonalCheckResult || secondDiagonalCheckResult;
        }

        /// <summary>
        /// Проверка одной диагонали.
        /// </summary>
        /// <param name="coords">Координаты ввода</param>
        /// <param name="xMax">Максимальное значение по X</param>
        /// <param name="yMax">Максимальное значение по Y</param>
        /// <param name="chr">Какой символ нужно проверять на победу</param>
        /// <param name="field">Игровое поле</param>
        /// <param name="isDirectionUp">Направление диагонали (true - вверх, false - вниз)</param>
        /// <returns>True если ход победный</returns>
        private static bool CheckDiagonal(Point2D coords, int xMax, int yMax, char chr, char[,] field, bool isDirectionUp)
        {
            // Переменная x юудет идти слева направо
            int x = Math.Clamp(coords.X - 2, 0, xMax);
            int xTarget = Math.Clamp(coords.X + 2, 0, xMax);

            // Переменная y будет идти вверх или вниз (в зависимости от параметра isDirectionUp)
            int y = isDirectionUp
            ? Math.Clamp(coords.Y + 2, 0, yMax)
            : Math.Clamp(coords.Y - 2, 0, yMax);

            int count = 0;

            // Проверка аналогична проверке по горизонтали и вертикали, но в этот раз обе переменные X и Y меняют свои значения
            while (x < xTarget)
            {
                int xNext = Math.Clamp(x + 1, 1, xMax);
                int yNext = isDirectionUp
                ? Math.Clamp(y - 1, 0, yMax)
                : Math.Clamp(y + 1, 1, yMax);

                if (field[y, x] == chr && field[yNext, xNext] == chr)
                {
                    count++;
                    if (count >= 2)
                        return true;
                }

                x++;
                if (isDirectionUp)
                    y = Math.Clamp(y - 1, 0, yMax);
                else
                    y = Math.Clamp(y + 1, 0, yMax);
            }

            return false;
        }
    }

}