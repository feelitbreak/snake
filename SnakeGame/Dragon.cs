namespace SnakeGame
{
    /// <summary>
    /// Class for the dragon.
    /// </summary>
    internal class Dragon
    {
        private const char HeadChar = '\u00A4';
        private const char BodyChar = '\u0030';
        private readonly List<Point> body;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dragon"/> class.
        /// </summary>
        public Dragon()
        {
            this.body = new List<Point>();

            const int initialHeadX = 5;
            const int initialHeadY = 5;

            Point head = new Point(initialHeadX, initialHeadY);
            Point middle = new Point(initialHeadX, initialHeadY - 1);
            Point tail = new Point(initialHeadX, initialHeadY - 2);

            this.body.Add(head);
            this.body.Add(middle);
            this.body.Add(tail);
        }

        /// <summary>
        /// Draws the dragon according to the points in the <see cref="body"/> list.
        /// </summary>
        public void Draw()
        {
            this.body[0].DrawChar(HeadChar);
            for (int i = 1; i < this.body.Count; i++)
            {
                this.body[i].DrawChar(BodyChar);
            }
        }
    }
}
