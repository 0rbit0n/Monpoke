using Monpoke.Commands;
using System.Linq;

namespace Monpoke
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputReader = (IInputReader)null;

            if (args?.Any() ?? false)
                inputReader = new FileInputReader(args.First());
            else
                inputReader = new ConsoleInputReader();

            var output = new Output();
            var commandFactory = new CommandFactory(output);
            var game = new Game(output);

            var controller = new GameController(inputReader, commandFactory, game);

            controller.PlayGame();
        }
    }
}
