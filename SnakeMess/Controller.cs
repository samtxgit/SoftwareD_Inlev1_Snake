using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            int boardW = Console.WindowWidth;
            int boardH = Console.WindowHeight;
            Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";

            GameObject gameObject = new GameObject(boardW, boardH);

            Stopwatch t = new Stopwatch();
            t.Start();
            while (!gameOver)
            {
                if (Console.KeyAvailable)
                {
                    handleUserInput();
                }
                if (!pause)
                {
                    if (t.ElapsedMilliseconds < 100)
                        continue;
                    t.Restart();
                    Point tail = new Point(gameObject.getSnakeBodysFirst());
                    Point head = new Point(gameObject.getSnakeBodysLast());
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
                    if (newH.X == gameObject.getApplePoint_X() && newH.Y == gameObject.getApplePoint_Y())
                    {
                        if (gameObject.getSnakeCount() + 1 >= boardW * boardH)
                            // No more room to place apples - game over.
                            gameOver = true;
                        else
                        {
                            inUse = gameObject.printNextApple();
                        }
                    }
                    if (!inUse)
                    {
                        gameObject.removeitemFromSnakeAtIndex(0);
                        foreach (Point x in gameObject.getSnake().bodyList)
                            if (x.X == newH.X && x.Y == newH.Y)
                            {
                                // Death by accidental self-cannibalism.
                                gameOver = true;
                                break;
                            }
                    }
                    if (!gameOver)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(head.X, head.Y);
                        Console.Write("0");
                        if (!inUse)
                        {
                            Console.SetCursorPosition(tail.X, tail.Y);
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(gameObject.getApplePoint_X(), gameObject.getApplePoint_Y());
                            Console.Write("$");
                            inUse = false;
                        }
                        gameObject.addToSnake(newH);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(newH.X, newH.Y);
                        Console.Write("@");
                        lastDirection = newDirection;
                    }
                }
            }
        }

        public static void handleUserInput() {
            ConsoleKeyInfo cki = Console.ReadKey(true);
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