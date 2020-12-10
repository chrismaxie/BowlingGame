using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;

namespace BowlingGameTests
{
    [TestClass]
    public class GameTests
    {
        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            var calculator = new Calculator();
            game = new Game(calculator);
        }

        [TestMethod]
        public void TestGutterGame()
        {
            for (var i = 0; i < 20; i++)
            {
                game.Roll(0);
            }

            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            for (var i = 0; i < 20; i++)
            {
                game.Roll(1);
            }

            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);

            for (var i = 0; i < 17; i++)
            {
                game.Roll(0);
            }

            Assert.AreEqual(16, game.Score());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            game.Roll(10);
            game.Roll(5);
            game.Roll(3);

            for (var i = 0; i < 16; i++)
            {
                game.Roll(0);
            }

            Assert.AreEqual(26, game.Score());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            for (var i = 0; i < 12; i++)
            {
                game.Roll(10);
            }

            Assert.AreEqual(300, game.Score());
        }

        [TestMethod]
        public void TestMaximumNumberOfRolls()
        {
            for (var i = 0; i < 18; i++)
            {
                game.Roll(0);
            }

            game.Roll(10);
            game.Roll(10);
            game.Roll(10);

            Assert.AreEqual(30, game.Score());
        }
    }
}
