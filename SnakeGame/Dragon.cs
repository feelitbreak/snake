namespace SnakeGame
{
    /// <summary>
    /// Class for the dragon.
    /// </summary>
    internal class Dragon
    {
        private const char HeadChar = '\u00A4';
        private const char BodyChar = '\u0030';
        private readonly Queue<Point> body;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dragon"/> class.
        /// </summary>
        public Dragon()
        {
            this.body = new Queue<Point>();

            const int initialHeadX = 5;
            const int initialHeadY = 5;

            Point head = new Point(initialHeadX, initialHeadY);
            head.DrawChar(HeadChar);
            Point middle = new Point(initialHeadX, initialHeadY - 1);
            middle.DrawChar(BodyChar);
            Point tail = new Point(initialHeadX, initialHeadY - 2);
            tail.DrawChar(BodyChar);

            this.body.Enqueue(head);
            this.body.Enqueue(middle);
            this.body.Enqueue(tail);
        }
    }
}
