namespace SnakeGame
{
    using System.Threading;

    internal class Game
    {
        private Timer? time;
        private Dragon dragon;

        public Game()
        {
            GameInterface.Draw();

            SoulGenerator soulGenerator = new SoulGenerator();
            soulGenerator.Generate();

            dragon = new Dragon();
        }

        public void Start()
        {
            int timePeriod = 200;
            time = new Timer(this.Play, null, 1000, timePeriod);
        }

        private void Play(object? obj)
        {
            this.dragon.Move();
        }
    }
}
