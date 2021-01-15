using Monpoke.Commands;
using System.Collections.Generic;
using System.Linq;

namespace Monpoke
{
    public class Game : IGame
    {
        public Game(ICommand[] commands)
        {
            this.commands = commands;
        }

        public void AddTeam(ITeam team)
        {
            teams.Add(team);
        }

        public ITeam GetTeam(string teamId)
        {
            return teams.First(t => t.Id == teamId);
        }

        public void Run()
        {
        }

        private ICommand[] commands;
        private List<ITeam> teams = new List<ITeam>();
    }
}
