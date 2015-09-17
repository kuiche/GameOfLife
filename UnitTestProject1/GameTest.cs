using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife.Core;

namespace UnitTestProject1
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TestDies()
        {
            int[,] map = {
                {1, 1, 1, 0, 1},
                {0, 0, 0, 0, 0},
                {0, 1, 1, 1, 0},
                {0, 0, 0, 0, 0},
                {1, 0, 0, 0, 1}
            };

            Game game = new Game(map);

            game.Update();

            Assert.AreEqual(0, game.GetPoint(0, 0));
            Assert.AreEqual(0, game.GetPoint(0, 2));
            Assert.AreEqual(0, game.GetPoint(2, 1));
            Assert.AreEqual(0, game.GetPoint(0, 4));
            Assert.AreEqual(0, game.GetPoint(4, 0));
            Assert.AreEqual(0, game.GetPoint(4, 4));
        }

        [TestMethod]
        public void TestCreatesNew()
        {
            int[,] map = {
                {0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 0, 1, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 0, 0, 1}
            };

            Game game = new Game(map);

            game.Update();

            Assert.AreEqual(1, game.GetPoint(2, 2));
            Assert.AreEqual(1, game.GetPoint(3, 3));
        }

        [TestMethod]
        public void TestStaysAlive()
        {
            int[,] map = {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 1, 0},
                {0, 0, 1, 1, 0},
                {0, 0, 0, 0, 0}
            };

            Game game = new Game(map);

            game.Update();
            
            Assert.AreEqual(1, game.GetPoint(3, 3));
        }
    }
}
