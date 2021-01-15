using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monpoke.Commands;
using Moq;

namespace Monpoke.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void CanAddTeam()
        {
            var team = new Team("MyTeam");

            game.AddTeam(team);

            game.GetTeam("MyTeam").Should().Be(team);
        }

        [TestMethod]
        public void CannotAddMoreThanTwoTeams()
        {
            Action forbiddenAction = () =>
            {
                for (int i = 0; i < 3; i++)
                    game.AddTeam(new Team(string.Empty));
            };

            forbiddenAction.Should().Throw<Exception>("Game can't have more than 2 teams.");
        }

        [TestMethod]
        public void CurrentTeamIsFirstAddedOneByDefault()
        {
            game.AddTeam(new Team("team1"));
            game.AddTeam(new Team("team2"));

            game.GetCurrentTeam().Id.Should().Be("team1");
        }

        [TestMethod]
        public void CurrentTeamSwitchesOnTurn()
        {
            game.AddTeam(new Team("team1"));
            game.AddTeam(new Team("team2"));

            var emptyCommand = new Mock<ICommand>().Object;

            game.MakeTurn(emptyCommand);

            game.GetCurrentTeam().Id.Should().Be("team2");
        }

        [TestMethod]
        public void CantMakeTurnIfTwoTeamsAreNotSet()
        {
            game.AddTeam(new Team("team1"));

            var emptyCommand = new Mock<ICommand>().Object;

            Action forbiddenTurn = () => game.MakeTurn(emptyCommand);

            forbiddenTurn.Should().Throw<Exception>().WithMessage("Two teams must be set to play the game.");
        }

        [TestMethod]
        public void TeamCanCheckForAliveMonpokes()
        {
            var team = new Team("team");
            var monpoke = new Monpoke("monpoke", 1, 1);
            monpoke.Damage(1);

            var deadMonpoke = monpoke;

            team.AddMonpoke(deadMonpoke);

            team.HasAliveMonpoke().Should().BeFalse();
        }

        IGame game = new Game();
    }
}
