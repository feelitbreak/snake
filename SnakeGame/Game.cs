namespace SnakeGame
{
    using System.Threading;

    /// <summary>
    /// Class for the main game.
    /// </summary>
    internal class Game
    {
        private readonly Dragon dragon;
        private Timer? time;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        public Game()
        {
            GameInterface.Draw();

            SoulGenerator soulGenerator = new SoulGenerator();
            soulGenerator.Generate();

            this.dragon = new Dragon();
        }

        /// <summary>
        /// Starts the <see cref="Game"/>.
        /// </summary>
        public void Start()
        {
            int timePeriod = 200;
            this.time = new Timer(this.Play, null, 1000, timePeriod);
        }

        private void Play(object? obj)
        {
            this.dragon.Move();
        }
    }
}
