namespace SnakeGame
{
    using System.Threading;

    /// <summary>
    /// Class for the main game.
    /// </summary>
    internal class Game
    {
        private readonly Dragon dragon;
        private readonly SoulGenerator soulGen;
        private Timer? time;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        public Game()
        {
            GameInterface.Draw();

            this.soulGen = new SoulGenerator();
            this.soulGen.Generate();

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

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    this.dragon.Turn(key);
                }
            }
        }

        private void Play(object? obj)
        {
            if (this.dragon.HitBorder() || this.dragon.HitDragon())
            {
                this.time!.Change(0, Timeout.Infinite);
            }
            else if (this.dragon.EatSoul(this.soulGen.Soul!))
            {
                this.soulGen.Generate();
            }
            else
            {
                this.dragon.Move();
            }
        }
    }
}
