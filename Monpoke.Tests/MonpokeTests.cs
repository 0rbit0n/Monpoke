using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monpoke.Tests
{
    [TestClass]
    public class MonpokeTests
    {
        [TestMethod]
        public void MonpokeHasId()
        {
            var monpoke = new Monpoke("monpoke", 1, 1);

            monpoke.Id.Should().Be("monpoke");
        }
    }
}
