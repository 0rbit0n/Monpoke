namespace Monpoke.Commands
{
    public class AttackCommand : ICommand
    {
        public void Execute(IGame game)
        {
            var currentTeam = game.GetCurrentTeam();
            var waitingTeam = game.GetWaitingTeam();


            currentTeam.GetCurrentMonpoke().Attack(waitingTeam.GetCurrentMonpoke());
        }

        public bool IsTurnCommand()
        {
            return true;
        }
    }
}
