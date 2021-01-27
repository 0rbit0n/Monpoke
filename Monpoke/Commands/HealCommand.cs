namespace Monpoke.Commands
{
    public class HealCommand : ICommand
    {
        public HealCommand(IOutput output, int healAMount)
        {
            this.healAmount = healAMount;
            this.output = output;
        }

        public void Execute(IGame game)
        {
            var monpoke = game.GetCurrentTeam().GetCurrentMonpoke();

            monpoke.Heal(healAmount);
        }

        public bool IsTurnCommand()
        {
            return true;
        }

        private IOutput output;
        private int healAmount;
    }
}