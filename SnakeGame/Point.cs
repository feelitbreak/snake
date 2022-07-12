namespace SnakeGame
{
    /// <summary>
    /// Class for a point with coordinates x and y.
    /// </summary>
    internal class Point
    {
        private readonly int x;
        private readonly int y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        /// <param name="x">Coordinate x.</param>
        /// <param name="y">Coordinate y.</param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Draws a specified char int the (x,y) position.
        /// </summary>
        /// <param name="c">The char to draw.</param>
        public void DrawChar(char c)
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(c);
        }
    }
}
