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
            const int timeBeforeStart = 500;
            const int initTimePeriod = 200;
            this.time = new Timer(this.Play, null, timeBeforeStart, initTimePeriod);
        }

        private void Play(object? obj)
        {
            this.dragon.Move();
        }
    }
}
