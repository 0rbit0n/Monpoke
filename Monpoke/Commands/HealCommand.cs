namespace Monpoke.Commands
{
    public class HealCommand : ICommand
    {
        public HealCommand(IOutput output, int healAMount)
        {
            this.healAMount = healAMount;
            this.output = output;
        }

        public void Execute(IGame game)
        {
            throw new System.NotImplementedException();
        }

        public bool IsTurnCommand()
        {
            throw new System.NotImplementedException();
        }

        private IOutput output;
        private int healAMount;
    }
}