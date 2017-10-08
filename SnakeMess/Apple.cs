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
        int _boardWidth;
        int _boardHeight;
        public Apple(int boardWidth, int boardHeight) {
            rnd = new Random();
            point = new Point();
            _boardHeight = boardHeight;
            _boardWidth = boardWidth;
            point.X = rnd.Next(0, boardWidth); point.Y = rnd.Next(0, boardHeight);
        }

        public void nextRandomPosition() {
            point.X = rnd.Next(0, _boardWidth); point.Y = rnd.Next(0, _boardHeight);

        }
        public bool checkSpawnCollision(Snake s) {
            foreach (Point  i in s.body)
            {
                if (i.X == point.X && i.Y == point.Y)
                {
                    return false;
                }
               
            }
            return true;
        }
}
}
