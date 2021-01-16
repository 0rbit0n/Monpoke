using Monpoke.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monpoke
{
    public class Game : IGame
    {
        public void AddTeam(ITeam team)
        {
            if (teams.Count == 2)
                throw new Exception("Game can't have more than 2 teams.");

            teams.Add(team);

            if (currentTeam == null)
                currentTeam = team;
        }

        public ITeam GetTeam(string teamId)
        {
            return teams.FirstOrDefault(t => t.Id == teamId);
        }

        public ITeam GetCurrentTeam()
        {
            return currentTeam;
        }

        public void RunCommand(ICommand command)
        {
            command.Execute(this);

            if(command.IsTurnCommand())
                SwitchCurrentTeam();
        }

        private void SwitchCurrentTeam()
        {
            if (teams.Count != 2)
                throw new Exception("Two teams must be set to play the game.");

            if (currentTeam == teams[0])
                currentTeam = teams[1];
            else
                currentTeam = teams[0];
        }

        public ITeam GetWaitingTeam()
        {
            if (currentTeam == teams[0])
                return teams[1];
            else
                return teams[2];
        }

        public bool IsOver()
        {
            return teams.Any(t => !t.HasAliveMonpoke());
        }

        private List<ITeam> teams = new List<ITeam>();
        private ITeam currentTeam;
    }
}
