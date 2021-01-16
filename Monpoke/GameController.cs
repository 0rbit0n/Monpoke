using Monpoke.Commands;

namespace Monpoke
{
    public class GameController
    {
        public GameController(IInputReader reader, ICommandFactory commandFactory, IGame game)
        {
            this.reader = reader;
            this.commandFactory = commandFactory;
            this.game = game;
        }

        public void PlayGame()
        {
            var commandsLines = reader.ReadInput();

            foreach (var commandLine in commandsLines)
            {
                var command = commandFactory.CreateCommand(commandLine);
                game.RunCommand(command);

                if (game.IsOver())
                {
                    game.OutputWinner();
                    return;
                }
            }
        }

        private IInputReader reader;
        private ICommandFactory commandFactory;
        private IGame game;
    }
}
