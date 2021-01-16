using System;

namespace Monpoke.Commands
{
    public class CreateCommand : ICommand
    {
        public CreateCommand(string teamId, string monpokeId, int hp, int attack)
        {
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
        }

        public bool IsTurnCommand()
        {
            return false;
        }

        private string teamId;
        private string monpokeId;
        private int hp;
        private int attack;
    }
}
