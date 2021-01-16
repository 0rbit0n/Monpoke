using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Monpoke.Tests
{
    [TestClass]
    public class OutputTests
    {
        [TestMethod]
        public void CanPrintOutput()
        {
            var writer = new StringWriter();
            System.Console.SetOut(writer);

            var output = new Output();
            output.WriteLine("Test Message");

            writer.GetStringBuilder().ToString().Should().Be("Test Message\r\n");
        }
    }
}
