namespace SnakeGame
{
    /// <summary>
    /// Class to generate souls for the dragon to eat.
    /// </summary>
    internal class SoulGenerator
    {
        private const char SoulChar = '\u0009';
        private readonly Random r;

        /// <summary>
        /// Initializes a new instance of the <see cref="SoulGenerator"/> class.
        /// </summary>
        public SoulGenerator()
        {
            this.r = new Random();
        }

        /// <summary>
        /// Generates a soul.
        /// </summary>
        public void Generate()
        {
            int x = this.r.Next(GameInterface.CornerX - 1) + 1;
            int y = this.r.Next(GameInterface.CornerY - 1) + 1;

            Point p = new Point(x, y);
            p.DrawChar(SoulChar);
        }
    }
}
