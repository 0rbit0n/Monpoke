using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monpoke.Commands;

namespace Monpoke.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void CanCreateGame()
        {
            new Game(Array.Empty<ICommand>());
        }

        [TestMethod]
        public void GameWithoutCommandsJustExist()
        {
            var game = new Game(Array.Empty<ICommand>());
            game.Run();
        }

        [TestMethod]
        public void CanAddTeam()
        {
            var game = new Game(Array.Empty<ICommand>());
            var team = new Team("MyTeam");

            game.AddTeam(team);

            game.GetTeam("MyTeam").Should().Be(team);
        }
    }
}
