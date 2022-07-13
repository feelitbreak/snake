namespace SnakeGame
{
    using System.Threading;

    internal class Game
    {
        public void Start()
        {
            GameInterface.Draw();

            SoulGenerator soulGenerator = new SoulGenerator();
            soulGenerator.Generate();

            Dragon dragon = new Dragon();

            int timePeriod = 200;
            Timer time = new Timer(Play, null, 0, timePeriod);

            Console.ReadLine();
        }

        private static void Play(object obj)
        {

        }
    }
}
