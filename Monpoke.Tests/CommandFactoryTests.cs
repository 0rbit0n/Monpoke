using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monpoke.Commands;

namespace Monpoke.Tests
{
    [TestClass]
    public class CommandFactoryTests
    {
        [TestMethod]
        public void CanCreateCreateCommand()
        {
            var factory = new CommandFactory();
            var actualCommand = factory.CreateCommand("CREATE Rocket Meekachu 3 1");

            var expectedCommand = new CreateCommand(teamId: "Rocket", monpokeId: "Meekachu", hp: 3, attack: 1);

            expectedCommand.ShouldHaveSameStateAs(actualCommand);
        } 

        [TestMethod]
        public void CanCreateAttackCommand()
        {
            var factory = new CommandFactory();
            var actualCommand = factory.CreateCommand("ATTACK");

            var expectedCommand = new AttackCommand();

            expectedCommand.ShouldHaveSameStateAs(actualCommand);
        }

        [TestMethod]
        public void CanCreateIChooseYouCommand()
        {
            var factory = new CommandFactory();
            var actualCommand = factory.CreateCommand("ICHOOSEYOU Meekachu");

            var expectedCommand = new IChooseYouCommand("Meekachu");

            expectedCommand.ShouldHaveSameStateAs(actualCommand);
        }

        [TestMethod]
        public void UnknownCommandThrowsException()
        {
            var factory = new CommandFactory();

            Action createCommand = () => { factory.CreateCommand("UNKNOWN COMMAND"); };

            createCommand.Should().Throw<Exception>().WithMessage("Unsupported command: 'UNKNOWN'.");
        }
    }
}
