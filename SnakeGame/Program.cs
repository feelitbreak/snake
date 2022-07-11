namespace SnakeGame
{
    public static class Program
    {
        public static void Main()
        {
            GameInterface.Draw();
            Console.ReadLine();
        }
    }

    internal struct Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void DrawChar(char c)
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(c);
        }
    }

    internal static class GameInterface
    {
        private const int CornerX = 85;
        private const int CornerY = 25;
        private const char CharOfBorders = '*';

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
                    Point p = new(x + i, y);
                    p.DrawChar(CharOfBorders);
                }
            }

            static void DrawVertical(int x, int y, int length)
            {
                for (int i = 0; i <= length; i++)
                {
                    Point p = new(x, y + i);
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