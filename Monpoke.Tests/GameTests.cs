using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monpoke.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void CanCreateGame()
        {
            new Game(Array.Empty<object>());
        }

        [TestMethod]
        public void GameWithoutCommandsJustExist()
        {
            var game = new Game(Array.Empty<object>());
            game.Run();
        }
    }
}
