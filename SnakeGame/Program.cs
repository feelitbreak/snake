namespace SnakeGame
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello, world!");
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

    internal class GameInterface
    {
        private const int middleX = 200;
        private const int middleY = 200;
        private const int lengthOfSide = 400;
        private const char charOfBorders = '*';

        public GameInterface()
        {
            drawBorders(middleX, middleY, lengthOfSide);
        }

        private void drawBorders(int x, int y, int lengthOfSide)
        {
            static void DrawUp(int x, int y, int length)
            {
                for (int i = 0; i < length; i++)
                {
                    Point p = new Point(x - (length / 2) + i, y - (length / 2));
                    p.DrawChar(charOfBorders);
                }
            }

            static void DrawRight(int x, int y, int length)
            {
                for (int i = 0; i < length; i++)
                {
                    Point p = new Point(x + (length / 2), y - (length / 2) + i);
                    p.DrawChar(charOfBorders);
                }
            }

            DrawUp(x, y, lengthOfSide);
            DrawRight(x, y, lengthOfSide);

        }


    }
}