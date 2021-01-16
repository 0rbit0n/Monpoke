using Monpoke.Commands;
using System;

namespace Monpoke
{
    public class GameController
    {
        public GameController(IEnvironment environment, IInputReader reader, ICommandFactory commandFactory, IGame game)
        {
            this.environment = environment;
            this.reader = reader;
            this.commandFactory = commandFactory;
            this.game = game;
        }

        public void PlayGame()
        {
            try
            {
                Play();
            }
            catch (Exception ex)
            {
                environment.Exit(1);
            }
        }

        public void Play()
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

        private IEnvironment environment;
        private IInputReader reader;
        private ICommandFactory commandFactory;
        private IGame game;
    }
}
