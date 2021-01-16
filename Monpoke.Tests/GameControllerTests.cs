using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monpoke.Commands;
using System;
using System.IO;

namespace Monpoke.Tests
{
    [TestClass]
    public class GameControllerTests
    {
        [TestMethod]
        public void ControllerCanPlayGame()
        {
            var input = "CREATE Rocket Meekachu 3 1\r\n" +
                        "CREATE Rocket Rastly 5 6\r\n" +
                        "CREATE Green Smorelax 2 1\r\n" +
                        "ICHOOSEYOU Meekachu\r\n" +
                        "ICHOOSEYOU Smorelax\r\n" +
                        "ATTACK\r\n" +
                        "ATTACK\r\n" +
                        "ICHOOSEYOU Rastly\r\n" +
                        "ATTACK\r\n" +
                        "ATTACK";

            var fileName = Guid.NewGuid().ToString();
            File.WriteAllText(fileName, input);

            var output = new StringOutput();
            var inputReader = new FileInputReader(fileName);
            var commandFactory = new CommandFactory(output);
            var game = new Game(output);

            var controller = new GameController(inputReader, commandFactory, game);

            controller.PlayGame();

            File.Delete(fileName);

            var actualOutput = output.GetText();
            var expectedOutput = "Meekachu has been assigned to team Rocket!\r\n" +
                                 "Rastly has been assigned to team Rocket!\r\n" +
                                 "Smorelax has been assigned to team Green!\r\n" +
                                 "Meekachu has entered the battle!\r\n" +
                                 "Smorelax has entered the battle!\r\n" +
                                 "Meekachu attacked Smorelax for 1 damage!\r\n" +
                                 "Smorelax attacked Meekachu for 1 damage!\r\n" +
                                 "Rastly has entered the battle!\r\n" +
                                 "Smorelax attacked Rastly for 1 damage!\r\n" +
                                 "Rastly attacked Smorelax for 6 damage!\r\n" +
                                 "Smorelax has been defeated!\r\n" +
                                 "Rocket is the winner!\r\n";

            expectedOutput.Should().Be(actualOutput);
        }
    }
}
