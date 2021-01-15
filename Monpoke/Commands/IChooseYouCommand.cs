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

        private readonly string monpokeId;
    }
}
