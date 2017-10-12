using System.Linq;

namespace SnakeMess
{
    class GameObject
    {
        #region Properties
        private Snake snake;
        private Apple apple;
        #endregion

        #region Constructor
        public GameObject(int boardWidth, int boardHeight)
        {
            snake = new Snake();
            apple = new Apple(boardWidth, boardHeight);
            apple.PrintFirstApple(snake);
        }
        #endregion

        #region Public methods
        public Point GetSnakeBodysFirst()
        {
            return snake.bodyList.First();
        }

        public Point GetSnakeBodysLast()
        {
            return snake.bodyList.Last();
        }

        public int GetApplePoint_X()
        {
            return apple.point.X;
        }

        public int GetApplePoint_Y()
        {
            return apple.point.Y;
        }

        public int GetSnakeCount()
        {
            return snake.bodyList.Count;
        }

        public bool PrintNextApple()
        {
            var inUse = apple.PrintNextApple(snake);
            return inUse;
        }

        public void RemoveitemFromSnakeAtIndex(int index)
        {
            snake.bodyList.RemoveAt(index);
        }

        public Snake GetSnake()
        {
            return snake;
        }

        public void AddToSnake(Point head)
        {
            snake.bodyList.Add(head);
        }
        #endregion
    }
}

