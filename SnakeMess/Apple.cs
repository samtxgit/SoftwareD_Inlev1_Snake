using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Apple
    {
        public Random rnd;
        public Point point;
        int _boardWith;
        int _boardHeiht;
        public Apple(int boardWidth, int boardHeight) {
            rnd = new Random();
            point = new Point();
            _boardHeiht = boardHeight;
            _boardWith = boardWidth;
            point.X = rnd.Next(0, boardWidth);
            point.Y = rnd.Next(0, boardHeight);
        }

        public void nextRandomPosition() {
            point.X = rnd.Next(0, _boardWith);
            point.Y = rnd.Next(0, _boardHeiht);

        }

        public void printFirstApple(Snake snake) {
            while (true)
            {
                this.nextRandomPosition();

                bool spot = true;
                foreach (Point i in snake.body)
                {
                    if (i.X == point.X && i.Y == point.Y)
                    {
                        spot = false;
                        break;
                    }
                }
                if (spot)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(point.X, point.Y);
                    Console.Write("$");
                    break;
                }
            }
        }

        public bool printNextApple(Snake snake) {
            bool inUse = false;
            while (true)
            {
                this.nextRandomPosition();
                bool found = true;
                foreach (Point i in snake.body)
                    if (i.X == this.point.X && i.Y == this.point.Y)
                    {
                        found = false;
                        break;
                    }
                if (found)
                {
                    inUse = true;
                    return inUse;
                }
            }
        }
    }
}
