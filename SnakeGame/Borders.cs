namespace SnakeGame
{
    /// <summary>
    /// Class for drawing the borders of the game.
    /// </summary>
    internal static class Borders
    {
        private const int CornerX = 85;
        private const int CornerY = 25;
        private const char CharOfBorders = '*';

        /// <summary>
        /// Draws the borders.
        /// </summary>
        public static void Draw()
        {
            DrawBorders(CornerX, CornerY);
        }

        private static void DrawBorders(int x, int y)
        {
            static void DrawHorizontal(int x, int y, int length)
            {
                for (int i = 0; i <= length; i++)
                {
                    Point p = new (x + i, y);
                    p.DrawChar(CharOfBorders);
                }
            }

            static void DrawVertical(int x, int y, int length)
            {
                for (int i = 0; i <= length; i++)
                {
                    Point p = new (x, y + i);
                    p.DrawChar(CharOfBorders);
                }
            }

            DrawHorizontal(0, 0, x);
            DrawVertical(x, 0, y);
            DrawHorizontal(0, y, x);
            DrawVertical(0, 0, y);
        }
    }
}
