using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monpoke.Commands;

namespace Monpoke.Tests
{
    [TestClass]
    public class AttackCommandTests
    {
        [TestInitialize]
        public void ArrangeAct()
        {
            game = new Game();

            game.MakeTurn(new CreateCommand(new StringOutput(), "Team1", "Monpoke1", hp: 5, attack: 5));
            game.MakeTurn(new CreateCommand(new StringOutput(), "Team2", "Monpoke2", hp: 5, attack: 5));
            game.MakeTurn(new IChooseYouCommand(new StringOutput(), "Monpoke1"));
            game.MakeTurn(new IChooseYouCommand(new StringOutput(), "Monpoke2"));

            output = new StringOutput();
            game.MakeTurn(new AttackCommand(output));
        }

        [TestMethod]
        public void CanKillVictimMonpoke()
        {
            game.GetTeam("Team2").HasAliveMonpoke().Should().BeFalse();
        }

        [TestMethod]
        public void AttackCommandPrintsCorrectOutput()
        {
            output.GetText().Should().Be("Monpoke1 attacked Monpoke2 for 5 damage!\r\n");
        }

        Game game;
        StringOutput output;
    }
}
