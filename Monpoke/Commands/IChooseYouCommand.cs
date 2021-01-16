namespace Monpoke.Commands
{
    public class IChooseYouCommand : ICommand
    {
        public IChooseYouCommand(string monpokeId)
        {
            this.monpokeId = monpokeId;
        }

        public void Execute(IGame game)
        {
            game.GetCurrentTeam().SetCurrentMonpoke(monpokeId);
        }

        public bool IsTurnCommand()
        {
            return true;
        }

        private readonly string monpokeId;
    }
}
