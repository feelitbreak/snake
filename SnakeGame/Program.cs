namespace SnakeGame
{
    /// <summary>
    /// Main project class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main function.
        /// </summary>
        public static void Main()
        {
            Console.CursorVisible = false;
            Game game = new Game();
            game.Start();
            Console.Read();
        }
    }
}
