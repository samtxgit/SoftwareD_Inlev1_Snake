
namespace SnakeMess
{
    class Point
    {
        #region Properties
        public int X
        {
            get; set;
        }
        public int Y
        {
            get; set;
        }
        #endregion

        #region Constructor
        public Point(int x = 0, int y = 0) { 
            X = x; Y = y; 
        }
        public Point(Point input) { 
            X = input.X; 
            Y = input.Y; 
        }
        #endregion
    }
}
