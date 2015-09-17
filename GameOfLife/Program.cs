using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] map = {
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            Game game = new Game(map);

            while (true)
            {
                Console.Clear();

                // set all in map to empty (0)
                for (int x = 0; x < game.GetMapHeight(); ++x)
                {
                    string s = "";
                    for (int y = 0; y < game.GetMapWidth(); ++y)
                    {
                        s += game.GetPoint(x, y);
                        if (y + 1 < game.GetMapWidth())
                        {
                            s += " ";
                        }
                    }

                    Console.WriteLine(s);
                }

                game.Update();

                Console.ReadLine();
            }
        }
    }
}
