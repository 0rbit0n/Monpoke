using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monpoke.Commands;

namespace Monpoke.Tests
{
    [TestClass]
    public class IChooseYouCommandTests
    {
        [TestMethod]
        public void IChooseYouSetsCurrentMonpoke()
        {
            var game = new Game();
            var team = new Team("team");

            var monpoke = new Monpoke("monpoke1", 1, 1);

            team.AddMonpoke(monpoke);

            game.AddTeam(team);

            var chooseMonpokeCommand = new IChooseYouCommand(monpoke.Id);

            chooseMonpokeCommand.Execute(game);

            team.GetCurrentMonpoke().Should().Be(monpoke);
        }

        [TestMethod]
        public void IChooseYouCommandIsTurnCommand()
        {
            new IChooseYouCommand("mon").IsTurnCommand().Should().BeTrue();
        }
    }
}
