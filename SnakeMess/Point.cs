using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Point
    {
        public const string Ok = "Ok";

        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x = 0, int y = 0) { X = x; Y = y; }
        public Point(Point input) { X = input.X; Y = input.Y; }
    }
}
