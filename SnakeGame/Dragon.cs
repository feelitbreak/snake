namespace SnakeGame
{
    internal class Dragon
    {
        private const char HeadChar = '\u0164';
        private const char BodyChar = '\u0035';
        private readonly List<Point> body;

        public Dragon()
        {
            this.body = new List<Point>();

            const int initialHeadX = 5;
            const int initialHeadY = 7;

            Point head = new Point(initialHeadX, initialHeadY);
            Point middle = new Point(initialHeadX, initialHeadY - 1);
            Point tail = new Point(initialHeadX, initialHeadY - 2);

            this.body.Add(head);
            this.body.Add(middle);
            this.body.Add(tail);
        }

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
