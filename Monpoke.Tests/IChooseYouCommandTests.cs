using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monpoke.Commands;

namespace Monpoke.Tests
{
    [TestClass]
    public class IChooseYouCommandTests
    {
        [TestInitialize]
        public void ArrangeAct()
        {
            var game = new Game();
            team = new Team("team");

            monpoke = new Monpoke("monpoke1", 1, 1);

            team.AddMonpoke(monpoke);

            game.AddTeam(team);

            output = new StringOutput();
            var chooseMonpokeCommand = new IChooseYouCommand(output, monpoke.Id);

            chooseMonpokeCommand.Execute(game);
        }

        [TestMethod]
        public void IChooseYouSetsCurrentMonpoke()
        {
            team.GetCurrentMonpoke().Should().Be(monpoke);
        }

        [TestMethod]
        public void IChooseYouCommandPrintsCorrectOutput()
        {
            output.GetText().Should().Be("monpoke1 has entered the battle!\r\n");
        }

        ITeam team;
        Monpoke monpoke;
        StringOutput output;
    }
}
