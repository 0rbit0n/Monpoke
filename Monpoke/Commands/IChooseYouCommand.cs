namespace Monpoke.Commands
{
    public class IChooseYouCommand : ICommand
    {
        public IChooseYouCommand(IOutput output, string monpokeId)
        {
            this.output = output;
            this.monpokeId = monpokeId;
        }

        public void Execute(IGame game)
        {
            game.GetCurrentTeam().SetCurrentMonpoke(monpokeId);

            var message = $"{monpokeId} has entered the battle!";
            output.WriteLine(message);
        }

        public bool IsTurnCommand()
        {
            return true;
        }

        private IOutput output;
        private string monpokeId;
    }
}
