using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monpoke.Commands;

namespace Monpoke.Tests
{
    [TestClass]
    public class IChooseYouCommandTypeTests
    {
        [TestMethod]
        public void IChooseYouCommandIsTurnCommand()
        {
            new IChooseYouCommand(null, "mon").IsTurnCommand().Should().BeTrue();
        }
    }
}
