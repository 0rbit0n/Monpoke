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
            throw new System.NotImplementedException();
        }

        private readonly string monpokeId;
    }
}
