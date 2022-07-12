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
            GameInterface.Draw();

            SoulGenerator soulGenerator = new SoulGenerator();
            soulGenerator.Generate();

            Console.ReadLine();
        }
    }
}