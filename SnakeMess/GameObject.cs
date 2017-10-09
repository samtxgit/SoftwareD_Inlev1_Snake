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
        public bool gameOver;
        public bool gamePause;
        public bool writeApple;

        public GameObject(int boardWidth, int boardHeight)
        {
            snake = new Snake();
            apple = new Apple(boardWidth,boardHeight );
            gameOver = false;
            gamePause = false;
            writeApple = false;
        }
    }
}
