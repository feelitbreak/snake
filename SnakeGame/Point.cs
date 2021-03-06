namespace SnakeGame
{
    /// <summary>
    /// Class for a point with coordinates x and y.
    /// </summary>
    internal class Point
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        /// <param name="x">Coordinate x.</param>
        /// <param name="y">Coordinate y.</param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets coordinate x of the <see cref="Point"/>.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets coordinate y of the <see cref="Point"/>.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Draws a specified char int the (x,y) position.
        /// </summary>
        /// <param name="c">The char to draw.</param>
        public void DrawChar(char c)
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(c);
        }

        /// <summary>
        /// Checks if the <see cref="Point"/> has the same coordiates as the given point.
        /// </summary>
        /// <param name="p">Point to compare to.</param>
        /// <returns>True, if the points have the same coordinates. False otherwise.</returns>
        public bool CompareCoordinates(Point p) => this.X == p.X && this.Y == p.Y;
    }
}
