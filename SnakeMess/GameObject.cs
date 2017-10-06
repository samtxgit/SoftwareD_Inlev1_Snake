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
        public bool goodGame;
        public bool pause;
        public bool inUse;
        public bool gameOver;
        public GameObject(int boardWith, int boardHeiht)
        {
            snake = new Snake();
            apple = new Apple(boardWith,boardHeiht );
            goodGame = false;
            pause = false;
            inUse = false;
            gameOver = false;
        }
    }
}

