namespace SnakeMess
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x = 0, int y = 0) { X = x; Y = y; }
        public Point(Point input) { X = input.X; Y = input.Y; }
    }
}
