namespace SnakeGame
{
    /// <summary>
    /// Class for the app that starts the  <see cref="Game"/>.
    /// </summary>
    internal static class DragonApp
    {
        private const int TimeBetweenGames = 1000;

        /// <summary>
        /// Runs the  <see cref="DragonApp"/>.
        /// </summary>
        public static void Run()
        {
            Console.CursorVisible = false;

            bool close = false;
            while (!close)
            {
                Game game = new Game();
                game.Start();
                close = game.Quit;
                if (game.Lost)
                {
                    Console.SetCursorPosition(GameInterface.CornerX / 3, GameInterface.CornerY / 2);
                    Console.WriteLine("You lost. Restarting the game.");
                    Thread.Sleep(TimeBetweenGames);
                }

                Console.Clear();
            }
        }
    }
}
