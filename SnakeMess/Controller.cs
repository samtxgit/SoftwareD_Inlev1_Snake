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
        // 0 = up, 1 = right, 2 = down, 3 = left
        public static void Main(string[] arguments)
        {
            newDirection = Direction.down;
            lastDirection = newDirection;
            int boardW = Console.WindowWidth;
            int boardH = Console.WindowHeight;
            Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";

            GameObject gameObject = new GameObject(boardW, boardH);
            gameObject.apple.printNextApple(gameObject.snake);

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
                    Point tail = new Point(gameObject.snake.body.First());
                    Point head = new Point(gameObject.snake.body.Last());
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
                    if (newH.X == gameObject.apple.point.X && newH.Y == gameObject.apple.point.Y)
                    {
                        if (gameObject.snake.body.Count + 1 >= boardW * boardH)
                            // No more room to place apples - game over.
                            gameOver = true;
                        else
                        {
                            while (true)
                            {
                                gameObject.apple.nextRandomPosition();
                                bool found = true;
                                foreach (Point i in gameObject.snake.body)
                                    if (i.X == gameObject.apple.point.X && i.Y == gameObject.apple.point.Y)
                                    {
                                        found = false;
                                        break;
                                    }
                                if (found)
                                {
                                    inUse = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!inUse)
                    {
                        gameObject.snake.body.RemoveAt(0);
                        foreach (Point x in gameObject.snake.body)
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
                            Console.SetCursorPosition(gameObject.apple.point.X, gameObject.apple.point.Y);
                            Console.Write("$");
                            inUse = false;
                        }
                        gameObject.snake.body.Add(newH);
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