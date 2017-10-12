using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SnakeMess
{
    class GameObject
    {
        private  Snake snake;
        private Apple apple;

        public GameObject(int boardWidth, int boardHeight)
        {
            snake = new Snake();
            apple = new Apple(boardWidth,boardHeight );
            apple.PrintFirstApple(snake);
        }

        public Point getSnakeBodysFirst() {
            return snake.bodyList.First();
        }

        public Point getSnakeBodysLast()
        {
            return snake.bodyList.Last();
        }

        public int getApplePoint_X() {
            return apple.point.X;
        }

        public int getApplePoint_Y()
        {
            return apple.point.Y;
        }

        public int getSnakeCount() {
            return snake.bodyList.Count;
        }

        public bool  printNextApple() {
            var inUse = apple.PrintNextApple(snake);
            return inUse;
        }

        public void removeitemFromSnakeAtIndex(int index) {
            snake.bodyList.RemoveAt(index);
        }

        public Snake getSnake() {
            return snake;
        }

        public void addToSnake(Point head) {
            snake.bodyList.Add(head);
        }
    }
}

