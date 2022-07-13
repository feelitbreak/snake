namespace SnakeGame
{
    /// <summary>
    /// Class to generate souls for the dragon to eat.
    /// </summary>
    internal class SoulGenerator
    {
        private const char SoulChar = 'o';
        private readonly Random r;

        /// <summary>
        /// Initializes a new instance of the <see cref="SoulGenerator"/> class.
        /// </summary>
        public SoulGenerator()
        {
            this.r = new Random();
        }

        /// <summary>
        /// Gets the generated soul.
        /// </summary>
        public Point? Soul { get; private set; }

        /// <summary>
        /// Generates a soul.
        /// </summary>
        public void Generate()
        {
            const int stepFromZero = 2;
            int x = this.r.Next(GameInterface.CornerX - stepFromZero - 1) + stepFromZero;
            int y = this.r.Next(GameInterface.CornerY - stepFromZero - 1) + stepFromZero;

            this.Soul = new Point(x, y);
            this.Soul.DrawChar(SoulChar);
        }
    }
}
