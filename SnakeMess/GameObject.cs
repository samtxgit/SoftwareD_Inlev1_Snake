using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class GameObject
    {
        Snake snake = new Snake();
        Apple apple = new Apple(1, 1 );
        bool goodGame = false;
        bool pause = false;
        bool inUse = false;
        bool gameOver = false;
    }
}

