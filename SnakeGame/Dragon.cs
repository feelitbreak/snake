namespace SnakeGame
{
    /// <summary>
    /// Enum class for directions.
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Represents the right direction.
        /// </summary>
        Right,

        /// <summary>
        /// Represents the left direction.
        /// </summary>
        Left,

        /// <summary>
        /// Represents the upward direction.
        /// </summary>
        Up,

        /// <summary>
        /// Represents the downward direction.
        /// </summary>
        Down,
    }

    /// <summary>
    /// Class for the dragon.
    /// </summary>
    internal class Dragon
    {
        private const char HeadChar = '\u00A4';
        private const char BodyChar = '\u0030';
        private readonly Queue<Point> body;
        private readonly SoulGenerator soulGen;
        private Direction direction;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dragon"/> class.
        /// </summary>
        /// <param name="soulGen">The reference to the <see cref="SoulGenerator"/> of the <see cref="Game"/>.</param>
        public Dragon(in SoulGenerator soulGen)
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

            this.body.Enqueue(tail);
            this.body.Enqueue(middle);
            this.body.Enqueue(head);

            this.direction = Direction.Down;

            this.soulGen = soulGen;
        }

        /// <summary>
        /// Moves the <see cref="Dragon"/> in the direction specified in the <see cref="direction"/> field.
        /// </summary>
        public void Move()
        {
            switch (this.direction)
            {
                case Direction.Right:
                    {
                        this.ShedTail();

                        Point head = this.GetHead();
                        head.DrawChar(BodyChar);

                        head = new Point(head.X + 1, head.Y);
                        head.DrawChar(HeadChar);
                        this.body.Enqueue(head);

                        break;
                    }

                case Direction.Left:
                    {
                        this.ShedTail();

                        Point head = this.GetHead();
                        head.DrawChar(BodyChar);

                        head = new Point(head.X - 1, head.Y);
                        head.DrawChar(HeadChar);
                        this.body.Enqueue(head);

                        break;
                    }

                case Direction.Up:
                    {
                        this.ShedTail();

                        Point head = this.GetHead();
                        head.DrawChar(BodyChar);

                        head = new Point(head.X, head.Y - 1);
                        head.DrawChar(HeadChar);
                        this.body.Enqueue(head);

                        break;
                    }

                case Direction.Down:
                    {
                        this.ShedTail();

                        Point head = this.GetHead();
                        head.DrawChar(BodyChar);

                        head = new Point(head.X, head.Y + 1);
                        head.DrawChar(HeadChar);
                        this.body.Enqueue(head);

                        break;
                    }
            }
        }

        /// <summary>
        /// Turns the <see cref="Dragon"/> in the specified direction, if it can.
        /// </summary>
        /// <param name="key">A <see cref="ConsoleKey"/> corresponding to the direction.</param>
        public void Turn(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    {
                        if (this.direction == Direction.Up || this.direction == Direction.Down)
                        {
                            this.direction = Direction.Right;
                        }

                        break;
                    }

                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    {
                        if (this.direction == Direction.Up || this.direction == Direction.Down)
                        {
                            this.direction = Direction.Left;
                        }

                        break;
                    }

                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    {
                        if (this.direction == Direction.Right || this.direction == Direction.Left)
                        {
                            this.direction = Direction.Up;
                        }

                        break;
                    }

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    {
                        if (this.direction == Direction.Right || this.direction == Direction.Left)
                        {
                            this.direction = Direction.Down;
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Checks if the dragon hit a border.
        /// </summary>
        /// <returns>True, if a border has been hit. False otherwise.</returns>
        public bool HitBorder() =>
            this.GetHead().X == 0
            || this.GetHead().Y == 0
            || this.GetHead().X == GameInterface.CornerX
            || this.GetHead().Y == GameInterface.CornerY;

        /// <summary>
        /// Checks if the dragon hit itself.
        /// </summary>
        /// <returns>True, if the dragon has been hit. False otherwise.</returns>
        public bool HitDragon()
        {
            Point head = this.GetHead();
            const int skipCount = 1;

            if (this.body.SkipLast(skipCount).Any(p => head.CompareCoordinates(p)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the dragon can eat a soul. If so, the dragon grows another tail.
        /// </summary>
        /// <returns>True, if the dragon can eat a soul. False otherwise.</returns>
        /// <param name="soul">A <see cref="Point"/> corresponding to the soul.</param>
        public bool EatSoul(Point soul)
        {
            if (this.GetHead().CompareCoordinates(soul))
            {
                Point head = this.GetHead();
                Point newHead = this.direction switch
                {
                    Direction.Right => new Point(head.X + 1, head.Y),
                    Direction.Left => new Point(head.X - 1, head.Y),
                    Direction.Up => new Point(head.X, head.Y - 1),
                    Direction.Down => new Point(head.X, head.Y + 1),
                    _ => throw new FormatException("Direction had an unexpected value.")
                };

                head.DrawChar(BodyChar);
                newHead.DrawChar(HeadChar);

                this.body.Enqueue(newHead);
                return true;
            }

            return false;
        }

        private Point GetHead()
        {
            return this.body.Last();
        }

        private void ShedTail()
        {
            Point p = this.body.Dequeue();
            if (!p.CompareCoordinates(this.soulGen.Soul!))
            {
                p.DrawChar(' ');
            }
        }
    }
}
