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
        }

        public ITeam GetTeam(string teamId)
        {
            return teams.FirstOrDefault(t => t.Id == teamId);
        }

        public void Run()
        {
        }

        private List<ITeam> teams = new List<ITeam>();
    }
}
