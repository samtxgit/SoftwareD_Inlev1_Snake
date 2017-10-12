using static System.Console;
using static System.ConsoleColor;
using System.Collections.Generic;

namespace SnakeMess
{
    class Snake
    {
        #region Public field
        public List<Point> bodyList;
        #endregion

        #region Constructor
        public Snake()
        {
            bodyList = new List<Point>();

            for (int i = 0; i < 4; i++)
            {
                bodyList.Add(new Point(10, 10));
                bodyList.Add(new Point(10, 10));
                bodyList.Add(new Point(10, 10));
                bodyList.Add(new Point(10, 10));
            }
            InitSnake();
        }
        #endregion

        #region Private Method
        private void InitSnake()
        {
            ForegroundColor = Green;
            SetCursorPosition(10, 10);
            Write("@");
        }
        #endregion

    }
}

