using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monpoke.Commands;
using System;

namespace Monpoke.Tests
{
    [TestClass]
    public class CreateCommandTests
    {
        [TestInitialize]
        public void ArrangeAct()
        {
            game = new Game();
            createCommand = new CreateCommand("team", "monpoke", 1, 1);

            createCommand.Execute(game);
        }

        [TestMethod]
        public void CreateCommandCreatesTeam()
        {
            var team = game.GetTeam("team");
            team.Should().NotBeNull();
        }

        [TestMethod]
        public void CreateCommandCreatesMonpoke()
        {
            var team = game.GetTeam("team");
            team.GetMonpoke("monpoke").Id.Should().Be("monpoke");
        }

        [TestMethod]
        public void CantCreateMonpokeTwice()
        {
            Action createSecondMonpoke = () => { createCommand.Execute(game); };

            createSecondMonpoke.Should().Throw<Exception>().WithMessage("Can't add monpoke 'monpoke' because it already exists.");
        }

        [TestMethod]
        public void CanAddTwoMonpokesIntoSameTeam()
        {
            var existingTeam = game.GetTeam("team");

            var newMonpokeCommand = new CreateCommand("team", "monpoke2", 2, 2);
            newMonpokeCommand.Execute(game);

            existingTeam.GetMonpoke("monpoke2").Id.Should().Be("monpoke2");
        }

        [TestMethod]
        public void CreateCommandIsNotTurnCommand()
        {
            new CreateCommand("team", "monpoke", 1, 1).IsTurnCommand().Should().BeFalse();
        }

        Game game;
        CreateCommand createCommand;
    }
}
