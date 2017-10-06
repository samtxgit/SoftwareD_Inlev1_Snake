using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Snake
    {
        public List<Point> body;
        public Snake() {
            body = new List<Point>();

            for (int i = 0; i < 4; i++) {
                body.Add(new Point(10, 10));
                body.Add(new Point(10, 10));
                body.Add(new Point(10, 10));
                body.Add(new Point(10, 10));
            }

        }

    }
}
