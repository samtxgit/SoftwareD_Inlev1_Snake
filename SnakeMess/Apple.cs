using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Apple
    {

        Apple(int boardWith, int boardHeiht) {
            Random rnd = new Random();
            Point point = new Point();
            point.X = rnd.Next(0, boardWith); point.Y = rnd.Next(0, boardHeiht);
        }
        
        
    }
}
