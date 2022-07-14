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
        /// Starts the <see cref="Game"/>.
        /// </summary>
        public void Start()
        {
            const int timeBeforeStart = 500;
            this.time = new Timer(this.Play, null, timeBeforeStart, this.timePeriod);

            bool quit = false;

            while (!quit)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape)
                    {
                        quit = true;
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
            }
            else if (this.dragon.EatSoul(this.soulGen.Soul!))
            {
                this.soulGen.Generate();
                this.soulsEaten++;
                if (this.soulsEaten % SoulsToChangeTime == 0)
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
