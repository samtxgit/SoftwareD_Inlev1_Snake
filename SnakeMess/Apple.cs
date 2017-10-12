using System;

namespace SnakeMess
{
    class Apple
    {
        #region fields
        private Random _rnd;
        private int _boardWith;
        private int _boardHeiht;

        public Point point;
        #endregion

        #region Constructor 
        public Apple(int boardWidth, int boardHeight)
        {
            _rnd = new Random();
            point = new Point();
            _boardHeiht = boardHeight;
            _boardWith = boardWidth;
            point.X = _rnd.Next(0, boardWidth);
            point.Y = _rnd.Next(0, boardHeight);
        }
        #endregion

        #region public methods
        public void NextRandomPosition()
        {
            point.X = _rnd.Next(0, _boardWith);
            point.Y = _rnd.Next(0, _boardHeiht);

        }

        public void PrintFirstApple(Snake snake)
        {
            while (true)
            {
                this.NextRandomPosition();

                bool spot = true;
                foreach (Point i in snake.bodyList)
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

        public bool PrintNextApple(Snake snake)
        {
            bool inUse = false;
            while (true)
            {
                this.NextRandomPosition();
                bool found = true;
                foreach (Point i in snake.bodyList)
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
        #endregion
    }
}

