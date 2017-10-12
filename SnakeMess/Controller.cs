using System;
using static System.Console;
using static System.ConsoleColor;
using System.Diagnostics;


namespace SnakeMess
{
    enum Direction { up, right, down, left };

    class Controller
    {
        #region Static fields
        private static bool GameOver = false;
        private static bool pause = false;
        private static bool InUse = false;
        private static Direction NewDirection;
        private static Direction LastDirection;
        #endregion

        #region Static method
        public static void HandleUserInput()
        {
            ConsoleKeyInfo cki = ReadKey(true);
            if (cki.Key == ConsoleKey.Escape)
                GameOver = true;
            else if (cki.Key == ConsoleKey.Spacebar)
                pause = !pause;
            else if (cki.Key == ConsoleKey.UpArrow && LastDirection != Direction.down)
                NewDirection = Direction.up;
            else if (cki.Key == ConsoleKey.RightArrow && LastDirection != Direction.left)
                NewDirection = Direction.right;
            else if (cki.Key == ConsoleKey.DownArrow && LastDirection != Direction.up)
                NewDirection = Direction.down;
            else if (cki.Key == ConsoleKey.LeftArrow && LastDirection != Direction.right)
                NewDirection = Direction.left;
        }
        #endregion

        #region Main()
        public static void Main(string[] arguments)
        {
            NewDirection = Direction.down;
            LastDirection = NewDirection;
            int boardW = WindowWidth;
            int boardH = WindowHeight;
            CursorVisible = false;
            Title = "Westerdals Oslo ACT - SNAKE";

            GameObject gameObject = new GameObject(boardW, boardH);

            Stopwatch t = new Stopwatch();
            t.Start();
            while (!GameOver)
            {
                if (KeyAvailable)
                {
                    HandleUserInput();
                }
                if (!pause)
                {
                    if (t.ElapsedMilliseconds < 100)
                        continue;
                    t.Restart();
                    Point tail = new Point(gameObject.GetSnakeBodysFirst());
                    Point head = new Point(gameObject.GetSnakeBodysLast());
                    Point newH = new Point(head);
                    switch (NewDirection)
                    {
                        case Direction.up:
                            newH.Y -= 1;
                            break;
                        case Direction.right:
                            newH.X += 1;
                            break;
                        case Direction.down:
                            newH.Y += 1;
                            break;
                        default:
                            newH.X -= 1;
                            break;
                    }
                    if (newH.X < 0 || newH.X >= boardW)
                        GameOver = true;
                    else if (newH.Y < 0 || newH.Y >= boardH)
                        GameOver = true;
                    if (newH.X == gameObject.GetApplePoint_X() && newH.Y == gameObject.GetApplePoint_Y())
                    {
                        if (gameObject.GetSnakeCount() + 1 >= boardW * boardH)
                            // No more room to place apples - game over.
                            GameOver = true;
                        else
                        {
                            InUse = gameObject.PrintNextApple();
                        }
                    }
                    if (!InUse)
                    {
                        gameObject.RemoveitemFromSnakeAtIndex(0);
                        foreach (Point x in gameObject.GetSnake().bodyList)
                            if (x.X == newH.X && x.Y == newH.Y)
                            {
                                // Death by accidental self-cannibalism.
                                GameOver = true;
                                break;
                            }
                    }
                    if (!GameOver)
                    {
                        ForegroundColor = Yellow;
                        SetCursorPosition(head.X, head.Y);
                        Write("0");
                        if (!InUse)
                        {
                            SetCursorPosition(tail.X, tail.Y);
                            Write(" ");
                        }
                        else
                        {
                            ForegroundColor = Green;
                            SetCursorPosition(gameObject.GetApplePoint_X(), gameObject.GetApplePoint_Y());
                            Write("$");
                            InUse = false;
                        }
                        gameObject.AddToSnake(newH);
                        ForegroundColor = Yellow;
                        SetCursorPosition(newH.X, newH.Y);
                        Write("@");
                        LastDirection = NewDirection;
                    }
                }
            }
        }
        #endregion
    }
}