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

        public Point (int x, int y)
        {
            X = x;
            Y = y;
        }

        public void DrawChar(char c)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(c);
        }

    }

    internal static class GameInterface
    {
        private const int cornerX = 85;
        private const int cornerY = 25;
        private const char charOfBorders = '*';

        public static void Draw()
        {
            DrawBorders(cornerX, cornerY);
        }

        private static void DrawBorders(int x, int y)
        {
            static void DrawHorizontal(int x, int y, int length)
            {
                for (int i = 0; i <= length; i++)
                {
                    Point p = new Point(x + i, y);
                    p.DrawChar(charOfBorders);
                }
            }

            static void DrawVertical(int x, int y, int length)
            {
                for (int i = 0; i <= length; i++)
                {
                    Point p = new Point(x, y + i);
                    p.DrawChar(charOfBorders);
                }
            }

            DrawHorizontal(0, 0, x);
            DrawVertical(x, 0, y);
            DrawHorizontal(0, y, x);
            DrawVertical(0, 0, y);

        }


    }
}