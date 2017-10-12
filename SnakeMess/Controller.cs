using System;
using static System.Console;
using static System.ConsoleColor;
using System.Diagnostics;


namespace SnakeMess
{
    class Controller
    {
        enum Direction { up , right, down, left };
        static bool gameOver = false;
        static bool pause = false;
        static bool inUse = false;
        static Direction newDirection;
        static Direction lastDirection;

        public static void Main(string[] arguments)
        {
            newDirection = Direction.down;
            lastDirection = newDirection;
            int boardW = WindowWidth;
            int boardH = WindowHeight;
            CursorVisible = false;
            Title = "Westerdals Oslo ACT - SNAKE";

            GameObject gameObject = new GameObject(boardW, boardH);

            Stopwatch t = new Stopwatch();
            t.Start();
            while (!gameOver)
            {
                if (KeyAvailable)
                {
                    handleUserInput();
                }
                if (!pause)
                {
                    if (t.ElapsedMilliseconds < 100)
                        continue;
                    t.Restart();
                    Point tail = new Point(gameObject.GetSnakeBodysFirst());
                    Point head = new Point(gameObject.GetSnakeBodysLast());
                    Point newH = new Point(head);
                    switch (newDirection)
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
                        gameOver = true;
                    else if (newH.Y < 0 || newH.Y >= boardH)
                        gameOver = true;
                    if (newH.X == gameObject.GetApplePoint_X() && newH.Y == gameObject.GetApplePoint_Y())
                    {
                        if (gameObject.GetSnakeCount() + 1 >= boardW * boardH)
                            // No more room to place apples - game over.
                            gameOver = true;
                        else
                        {
                            inUse = gameObject.PrintNextApple();
                        }
                    }
                    if (!inUse)
                    {
                        gameObject.RemoveitemFromSnakeAtIndex(0);
                        foreach (Point x in gameObject.GetSnake().bodyList)
                            if (x.X == newH.X && x.Y == newH.Y)
                            {
                                // Death by accidental self-cannibalism.
                                gameOver = true;
                                break;
                            }
                    }
                    if (!gameOver)
                    {
                        ForegroundColor = Yellow;
                        SetCursorPosition(head.X, head.Y);
                        Write("0");
                        if (!inUse)
                        {
                            SetCursorPosition(tail.X, tail.Y);
                            Write(" ");
                        }
                        else
                        {
                            ForegroundColor = Green;
                            SetCursorPosition(gameObject.GetApplePoint_X(), gameObject.GetApplePoint_Y());
                            Write("$");
                            inUse = false;
                        }
                        gameObject.AddToSnake(newH);
                        ForegroundColor = Yellow;
                        SetCursorPosition(newH.X, newH.Y);
                        Write("@");
                        lastDirection = newDirection;
                    }
                }
            }
        }

        public static void handleUserInput() {
            ConsoleKeyInfo cki = ReadKey(true);
            if (cki.Key == ConsoleKey.Escape)
                gameOver = true;
            else if (cki.Key == ConsoleKey.Spacebar)
                pause = !pause;
            else if (cki.Key == ConsoleKey.UpArrow && lastDirection != Direction.down)
                newDirection = Direction.up;
            else if (cki.Key == ConsoleKey.RightArrow && lastDirection != Direction.left)
                newDirection = Direction.right;
            else if (cki.Key == ConsoleKey.DownArrow && lastDirection != Direction.up)
                newDirection = Direction.down;
            else if (cki.Key == ConsoleKey.LeftArrow && lastDirection != Direction.right)
                newDirection = Direction.left;
        }
    }
}