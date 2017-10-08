using System.Collections.Generic;

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
