namespace SnakeGame
{
    using System.Threading;

    /// <summary>
    /// Class for the main game.
    /// </summary>
    internal class Game
    {
        private const int SoulsToChangeTime = 5;
        private const double TimePeriodChange = 1.2;
        private const int MinTimePeriod = 50;
        private readonly Dragon dragon;
        private readonly SoulGenerator soulGen;
        private Timer? time;
        private int soulsEaten = 0;
        private int timePeriod = 120;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        public Game()
        {
            GameInterface.Draw();

            this.soulGen = new SoulGenerator();
            this.soulGen.Generate();

            this.dragon = new Dragon(this.soulGen);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Game"/> class.
        /// </summary>
        ~Game()
        {
            this.time?.Dispose();
        }

        /// <summary>
        /// Gets a value indicating whether the player has quit the game.
        /// </summary>
        public bool Quit { get; private set; } = false;

        /// <summary>
        /// Gets a value indicating whether the player has lost the game.
        /// </summary>
        public bool Lost { get; private set; } = false;

        /// <summary>
        /// Starts the <see cref="Game"/>.
        /// </summary>
        public void Start()
        {
            const int timeBeforeStart = 500;
            this.time = new Timer(this.Play, null, timeBeforeStart, this.timePeriod);

            while (!this.Quit && !this.Lost)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape)
                    {
                        this.Quit = true;
                    }
                    else
                    {
                        this.dragon.Turn(key);
                    }
                }
            }
        }

        private void Play(object? obj)
        {
            if (this.dragon.HitBorder() || this.dragon.HitDragon())
            {
                this.time!.Change(0, Timeout.Infinite);
                this.Lost = true;
            }
            else if (this.dragon.EatSoul(this.soulGen.Soul!))
            {
                GameInterface.ChangeScore(this.soulsEaten * 10);

                this.soulGen.Generate();
                this.soulsEaten++;
                if (this.soulsEaten % SoulsToChangeTime == 0 && this.timePeriod > MinTimePeriod)
                {
                    this.timePeriod = (int)(this.timePeriod / TimePeriodChange);
                    this.time!.Change(0, this.timePeriod);
                }
            }
            else
            {
                this.dragon.Move();
            }
        }
    }
}
