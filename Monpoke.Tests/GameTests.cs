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
        public void CanAddTeam()
        {
            var game = new Game();
            var team = new Team("MyTeam");

            game.AddTeam(team);

            game.GetTeam("MyTeam").Should().Be(team);
        }

        [TestMethod]
        public void CannotAddMoreThanTwoTeams()
        {
            var game = new Game();

            Action forbiddenAction = () =>
            {
                for (int i = 0; i < 3; i++)
                    game.AddTeam(new Team(string.Empty));
            };

            forbiddenAction.Should().Throw<Exception>("Game can't have more than 2 teams.");
        }


    }
}
