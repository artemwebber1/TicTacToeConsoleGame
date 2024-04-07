using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsoleGame.Source
{
    /// <summary>
    /// Координаты, введённые игроком.
    /// </summary>
    public struct Point2D
    {
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Позиция по X (колонна).
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Позиция по Y (строка).
        /// </summary>
        public int Y { get; }
    }
}
