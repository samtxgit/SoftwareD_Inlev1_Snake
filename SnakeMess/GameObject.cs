using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class GameObject
    {
        public  Snake snake;
        public Apple apple;

        public GameObject(int boardWidth, int boardHeight)
        {
            snake = new Snake();
            apple = new Apple(boardWidth,boardHeight );
        }
    }
}

