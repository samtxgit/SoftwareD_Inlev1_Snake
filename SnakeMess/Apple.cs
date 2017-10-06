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
        public Apple(int boardWith, int boardHeiht) {
            rnd = new Random();
            point = new Point();
            _boardHeiht = boardHeiht;
            _boardWith = boardWith;
            point.X = rnd.Next(0, boardWith); point.Y = rnd.Next(0, boardHeiht);
        }

        public void nextRandomPosition() {
            point.X = rnd.Next(0, _boardWith); point.Y = rnd.Next(0, _boardHeiht);

        }
    }
}
