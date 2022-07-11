namespace SnakeGame
{
    public static class Program
    {
        public static void Main()
        {
            GameInterface gi = new();
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

    internal class GameInterface
    {
        private const int middleX = 35;
        private const int middleY = 35;
        private const int lengthOfSide = 70;
        private const char charOfBorders = '#';

        public GameInterface()
        {
            DrawBorders(middleX, middleY, lengthOfSide);
        }

        private static void DrawBorders(int x, int y, int lengthOfSide)
        {
            static void DrawHorizontal(int x, int y, int length)
            {
                for (int i = 0; i < length; i++)
                {
                    Point p = new Point(x + i, y);
                    p.DrawChar(charOfBorders);
                }
            }

            static void DrawVertical(int x, int y, int length)
            {
                for (int i = 0; i < length; i++)
                {
                    Point p = new Point(x, y + i);
                    p.DrawChar(charOfBorders);
                }
            }

            DrawHorizontal(x - (lengthOfSide / 2), y - (lengthOfSide / 2), lengthOfSide);
            DrawVertical(x + (lengthOfSide / 2), y - (lengthOfSide / 2), lengthOfSide);
            DrawHorizontal(x - (lengthOfSide / 2), y + (lengthOfSide / 2), lengthOfSide);
            DrawVertical(x - (lengthOfSide / 2), y - (lengthOfSide / 2), lengthOfSide);

        }


    }
}