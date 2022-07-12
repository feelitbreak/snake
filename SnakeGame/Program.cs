namespace SnakeGame
{
    public static class Program
    {
        public static void Main()
        {
            Borders.Draw();
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
}