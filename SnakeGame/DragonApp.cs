namespace SnakeGame
{
    /// <summary>
    /// Class for the app that starts the  <see cref="Game"/>.
    /// </summary>
    internal class DragonApp
    {
        /// <summary>
        /// Runs the  <see cref="DragonApp"/>.
        /// </summary>
        public void Run()
        {
            Console.CursorVisible = false;
            Game game = new Game();
            game.Start();
        }
    }
}
