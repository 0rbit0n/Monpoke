using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Monpoke.Tests
{
    [TestClass]
    public class FileInputReaderTests
    {
        [TestMethod]
        public void CanReadInputLinesFromFile()
        {
            var fileName = Guid.NewGuid().ToString();
            File.WriteAllText(fileName, "line1\r\n   \r\nline2\r\n\r\n");

            var fileReader = new FileInputReader(fileName);

            var actalInput = fileReader.ReadInput();

            File.Delete(fileName);

            var expectedInput = new[] { "line1", "line2" };

            actalInput.Should().BeEquivalentTo(expectedInput);
        }
    }

}
