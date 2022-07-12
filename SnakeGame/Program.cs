namespace SnakeGame
{
    /// <summary>
    /// Main project class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main function.
        /// </summary>
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