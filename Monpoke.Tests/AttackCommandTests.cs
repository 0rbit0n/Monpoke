using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monpoke.Commands;

namespace Monpoke.Tests
{
    [TestClass]
    public class AttackCommandTests
    {
        [TestMethod]
        public void CanKillVictimMonpoke()
        {
            var game = new Game();

            game.MakeTurn(new CreateCommand("Team1", "Monpoke1", hp: 5, attack: 5));
            game.MakeTurn(new CreateCommand("Team2", "Monpoke2", hp: 5, attack: 5));
            game.MakeTurn(new IChooseYouCommand("Monpoke1"));
            game.MakeTurn(new IChooseYouCommand("Monpoke2"));

            game.MakeTurn(new AttackCommand());

            game.GetTeam("Team2").HasAliveMonpoke().Should().BeFalse();
        }

        [TestMethod]
        public void AttackCommandIsTurnCommand()
        {
            new AttackCommand().IsTurnCommand().Should().BeTrue();
        }
    }
}
