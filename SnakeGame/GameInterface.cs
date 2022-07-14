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
        /// Draws the game interface.
        /// </summary>
        public static void Draw()
        {
            DrawBorders();
            DrawTutorial();
            DrawScore();
            ChangeScore(0);
            DrawCredits();
        }

        /// <summary>
        /// Puts the current score on the screen.
        /// </summary>
        /// <param name="score">An <see cref="int"/> value indicating the score to be put on screen.</param>
        public static void ChangeScore(int score)
        {
            const int ScoreX = 11;
            const int ScoreY = CornerY + 2;

            Console.SetCursorPosition(ScoreX, ScoreY);
            Console.WriteLine(score.ToString());
        }

        private static void DrawBorders()
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

            DrawHorizontal(0, 0, CornerX);
            DrawVertical(CornerX, 0, CornerY);
            DrawHorizontal(0, CornerY, CornerX);
            DrawVertical(0, 0, CornerY);
        }

        private static void DrawTutorial()
        {
            const int TutorialX = CornerX + 4;
            const int TutorialY = CornerY / 5;

            Console.SetCursorPosition(TutorialX, TutorialY);
            Console.WriteLine("Use W, A, S, D,");
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

        private static void DrawScore()
        {
            const int ScoreX = 4;
            const int ScoreY = CornerY + 2;

            Console.SetCursorPosition(ScoreX, ScoreY);
            Console.WriteLine("Score:");
        }

        private static void DrawCredits()
        {
            const int CreditsX = CornerX + 4;
            const int CreditsY = (CornerY / 5) + 13;

            Console.SetCursorPosition(CreditsX, CreditsY);
            Console.WriteLine("Credits:");
            Console.SetCursorPosition(CreditsX, CreditsY + 1);
            Console.WriteLine("Made by Alexey Kendys.");
            Console.SetCursorPosition(CreditsX, CreditsY + 3);
            Console.WriteLine("A big thank you to");
            Console.SetCursorPosition(CreditsX, CreditsY + 4);
            Console.WriteLine("Juzeppe Krucheletti");
            Console.SetCursorPosition(CreditsX, CreditsY + 5);
            Console.WriteLine("and Marti Vermesheleva");
            Console.SetCursorPosition(CreditsX, CreditsY + 6);
            Console.WriteLine("for ideas and testing.");
        }
    }
}
