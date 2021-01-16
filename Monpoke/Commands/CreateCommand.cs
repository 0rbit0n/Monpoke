using System;

namespace Monpoke.Commands
{
    public class CreateCommand : ICommand
    {
        public CreateCommand(IOutput output, string teamId, string monpokeId, int hp, int attack)
        {
            this.output = output;
            this.teamId = teamId;
            this.monpokeId = monpokeId;
            this.hp = hp;
            this.attack = attack;
        }

        public void Execute(IGame game)
        {
            var team = game.GetTeam(teamId);

            if (team == null)
            {
                team = new Team(teamId);
                game.AddTeam(team);
            }

            var monpoke = new Monpoke(monpokeId, hp, attack);

            var monpokeExists = team.GetMonpoke(monpokeId) != null;
            if (monpokeExists)
                throw new Exception($"Can't add monpoke '{monpokeId}' because it already exists.");

            team.AddMonpoke(monpoke);

            var message = $"{monpoke.Id} has been assigned to team {team.Id}!";
            output.WriteLine(message);
        }

        public bool IsTurnCommand()
        {
            return false;
        }

        private readonly IOutput output;
        private string teamId;
        private string monpokeId;
        private int hp;
        private int attack;
    }
}
