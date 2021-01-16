using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monpoke.Commands;

namespace Monpoke.Tests
{
    [TestClass]
    public class CreateCommandTypeTests
    {
        [TestMethod]
        public void CreateCommandIsNotTurnCommand()
        {
            new CreateCommand(null, "team", "monpoke", 1, 1).IsTurnCommand().Should().BeFalse();
        }
    }
}
