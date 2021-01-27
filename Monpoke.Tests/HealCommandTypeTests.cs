using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monpoke.Commands;

namespace Monpoke.Tests
{
    [TestClass]
    public class HealCommandTypeTests
    {
        [TestMethod]
        public void HealCommandIsTurnCommand()
        {
            new HealCommand(null, 4).IsTurnCommand().Should().BeTrue();
        }
    }
}