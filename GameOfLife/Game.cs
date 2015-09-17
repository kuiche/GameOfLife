using System;
using System.Collections;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Game
    {
        private int[,] map;

        public Game(int size) : this(size, size) { }

        public Game(int xSize, int ySize)
        {
            // initialse the map
            map = new int[xSize, ySize];

            // set all in map to empty (0)
            for (int x = 0; x < map.GetLength(0); ++x) {
                for (int y = 0; y < map.GetLength(1); ++y)
                {
                    map[x, y] = 0;
                }
            }
        }

        public Game(int[,] map)
        {
            this.map = map;
        }

        /// <summary>
        /// Set the value of a point at (x, y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="value"></param>
        public void SetPoint(int x, int y, int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Value given must be greater or equal to 0");
            }

            map[x, y] = value;
        }

        /// <summary>
        /// Get the value of the cell at (x, y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int GetPoint(int x, int y)
        {
            return map[x, y];
        }

        /// <summary>
        ///  Updates the map in accordance to the rules of the game of life
        /// </summary>
        public void Update()
        {
            // initialse the map
            int xLen = map.GetLength(0), yLen = map.GetLength(1);

            int[,] newMap = new int[xLen, yLen];

            // set all in map to empty (0)
            for (int x = 0; x < xLen; ++x)
            {
                for (int y = 0; y < yLen; ++y)
                {
                    int neighbours = 0;

                    for (int i = x - 1; i <= x + 1; ++i)
                    {
                        for (int j = y - 1; j <= y + 1; ++j)
                        {
                            if (
                                // don't test if it is the same node
                                (i == x && j == y) ||
                                // don't test if out of bounds
                                i >= xLen || i < 0 ||
                                j >= yLen || j < 0
                            )
                            {
                                continue;
                            }

                            if (map[i,j] > 0)
                            {
                                ++neighbours;
                            }
                        }
                    }

                    // any cell with 3 will be alive next round, any live cell with 2
                    // will also live to the next round
                    if (map[x,y] == 1 && neighbours == 2 || neighbours == 3)
                    {
                        newMap[x, y] = 1;
                    }
                    else
                    {
                        newMap[x, y] = 0;
                    }
                }
            }

            this.map = newMap;
        }

        /// <summary>
        ///  Gets the map height
        /// </summary>
        /// <returns>The height of the map</returns>
        public int GetMapHeight()
        {
            return this.map.GetLength(0);
        }

        /// <summary>
        ///  Gets the map width
        /// </summary>
        /// <returns>The width of the map</returns>
        public int GetMapWidth()
        {
            return this.map.GetLength(1);
        }
    }
}
