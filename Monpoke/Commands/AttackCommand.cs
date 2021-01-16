namespace Monpoke.Commands
{
    public class AttackCommand : ICommand
    {
        public AttackCommand(IOutput output)
        {
            this.output = output;
        }

        public void Execute(IGame game)
        {
            var currentTeam = game.GetCurrentTeam();
            var waitingTeam = game.GetWaitingTeam();

            var attacker = currentTeam.GetCurrentMonpoke();
            var victim = waitingTeam.GetCurrentMonpoke();

            attacker.Attack(victim);

            var message = $"{attacker.Id} attacked {victim.Id} for {attacker.GetAttackPower()} damage!";
            output.WriteLine(message);

            if (!victim.IsAlive())
            {
                output.WriteLine($"{victim.Id} has been defeated!");
            }
        }

        public bool IsTurnCommand()
        {
            return true;
        }

        private readonly IOutput output;
    }
}
