namespace Monpoke.Commands
{
    public class IChooseYouCommand : ICommand
    {
        public IChooseYouCommand(string monpokeId)
        {
            this.monpokeId = monpokeId;
        }

        private readonly string monpokeId;
    }
}
