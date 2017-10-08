using System;
using System.Linq;
using System.Diagnostics;

namespace SnakeMess
{
	class SnakeMess
	{
		public static void Main(string[] arguments)
		{
			short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
			short last = newDir;
            GameBoard board = new GameBoard();
            GameObject gameObject = new GameObject(board.W, board.H);

            do
            {
                gameObject.apple.nextRandomPosition();
                

            } while (!gameObject.apple.checkSpawnCollision(gameObject.snake));
            board.writeApple(gameObject.apple.point.X, gameObject.apple.point.Y);

            Stopwatch t = new Stopwatch();
			t.Start();
			while (!gameObject.gameOver) {
				if (Console.KeyAvailable) {
					ConsoleKeyInfo cki = Console.ReadKey(true);
					if (cki.Key == ConsoleKey.Escape)
						gameObject.gameOver = true;
					else if (cki.Key == ConsoleKey.Spacebar)
						gameObject.gamePause= !gameObject.gamePause;
					else if (cki.Key == ConsoleKey.UpArrow && last != 2)
						newDir = 0;
					else if (cki.Key == ConsoleKey.RightArrow && last != 3)
						newDir = 1;
					else if (cki.Key == ConsoleKey.DownArrow && last != 0)
						newDir = 2;
					else if (cki.Key == ConsoleKey.LeftArrow && last != 1)
						newDir = 3;
				}
				if (!gameObject.gamePause) {
					if (t.ElapsedMilliseconds < 100)
						continue;
					t.Restart();
					Point tail = new Point(gameObject.snake.body.First());
					Point head = new Point(gameObject.snake.body.Last());
					Point newH = new Point(head);
					switch (newDir) {
						case 0:
							newH.Y -= 1;
							break;
						case 1:
							newH.X += 1;
							break;
						case 2:
							newH.Y += 1;
							break;
						default:
							newH.X -= 1;
							break;
					}
					if (newH.X < 0 || newH.X >= board.W)
						gameObject.gameOver = true;
					else if (newH.Y < 0 || newH.Y >= board.H)
                        gameObject.gameOver = true;
					if (newH.X == gameObject.apple.point.X && newH.Y == gameObject.apple.point.Y) {
						if (gameObject.snake.body.Count + 1 >= board.W * board.H)
                            // No more room to place apples - game over.
                            gameObject.gameOver = true;
						else {
							while (true) {
                                gameObject.apple.nextRandomPosition();
                                bool found = true;
								foreach (Point i in gameObject.snake.body)
									if (i.X == gameObject.apple.point.X && i.Y == gameObject.apple.point.Y) {
										found = false;
										break;
									}
								if (found) {
                                    gameObject.writeApple = true;
									break;
								}
							}
						}
					}
					if (!gameObject.writeApple) {
                        gameObject.snake.body.RemoveAt(0);
						foreach (Point x in gameObject.snake.body)
							if (x.X == newH.X && x.Y == newH.Y) {
								// Death by accidental self-cannibalism.
								gameObject.gameOver = true;
								break;
							}
					}
					if (!gameObject.gameOver){
                        board.writeBody(head.X, head.Y);

                        if (!gameObject.writeApple)
                        {
                            board.eraseTail(tail.X, tail.Y);
						} else {
                            board.writeApple(gameObject.apple.point.X, gameObject.apple.point.Y);
                            gameObject.writeApple = false;
						}
                        gameObject.snake.body.Add(newH);
                        board.writeHead(newH.X, newH.Y);
						last = newDir;
					}
				}
			}
		}
	}
}