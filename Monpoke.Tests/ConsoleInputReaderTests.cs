using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Monpoke.Tests
{
    [TestClass]
    public class ConsoleInputReaderTests
    {
        [TestMethod]
        public void CanReadInputLinesFromConsole()
        {
            var consoleReader = new ConsoleInputReader();
            var stringReader = new StringReader("line1\r\n   \r\nline2\r\n\r\n");

            Console.SetIn(stringReader);

            var actalInput = consoleReader.ReadInput();

            var expectedInput = new[] { "line1", "line2" };

            actalInput.Should().Equal(expectedInput);
        }
    }

}
