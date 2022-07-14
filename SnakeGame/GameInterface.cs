namespace SnakeGame
{
    /// <summary>
    /// Class for drawing the interface of the game.
    /// </summary>
    internal static class GameInterface
    {
        /// <summary>
        /// The x coordinate of the low right corner of the interface.
        /// </summary>
        public const int CornerX = 85;

        /// <summary>
        /// The y coordinate of the low right corner of the interface.
        /// </summary>
        public const int CornerY = 25;

        private const char CharOfBorders = '*';

        /// <summary>
        /// Draws the borders.
        /// </summary>
        public static void Draw()
        {
            DrawBorders(CornerX, CornerY);
            DrawTutorial();
        }

        private static void DrawBorders(int x, int y)
        {
            static void DrawHorizontal(int x, int y, int length)
            {
                for (int i = 0; i <= length; i++)
                {
                    Point p = new (x + i, y);
                    p.DrawChar(CharOfBorders);
                }
            }

            static void DrawVertical(int x, int y, int length)
            {
                for (int i = 0; i <= length; i++)
                {
                    Point p = new (x, y + i);
                    p.DrawChar(CharOfBorders);
                }
            }

            DrawHorizontal(0, 0, x);
            DrawVertical(x, 0, y);
            DrawHorizontal(0, y, x);
            DrawVertical(0, 0, y);
        }

        private static void DrawTutorial()
        {
            const int TutorialX = CornerX + 4;
            const int TutorialY = CornerY / 5;
            Console.SetCursorPosition(TutorialX, TutorialY);
            Console.WriteLine("Use W, A, S, D");
            Console.SetCursorPosition(TutorialX, TutorialY + 1);
            Console.WriteLine("or arrows to move.");
            Console.SetCursorPosition(TutorialX, TutorialY + 3);
            Console.WriteLine("Esc to quit.");
            Console.SetCursorPosition(TutorialX, TutorialY + 5);
            Console.WriteLine("Eat as many souls as you can");
            Console.SetCursorPosition(TutorialX, TutorialY + 6);
            Console.WriteLine("and become the mightiest");
            Console.SetCursorPosition(TutorialX, TutorialY + 7);
            Console.WriteLine("dragon alive!");
        }
    }
}
