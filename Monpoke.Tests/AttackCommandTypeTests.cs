using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monpoke.Commands;

namespace Monpoke.Tests
{
    [TestClass]
    public class AttackCommandTypeTests
    {
        [TestMethod]
        public void AttackCommandIsTurnCommand()
        {
            new AttackCommand(null).IsTurnCommand().Should().BeTrue();
        }
    }
}
