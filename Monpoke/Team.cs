using System.Linq;
using System.Collections.Generic;

namespace Monpoke
{
    public class Team : ITeam
    {
        public Team(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public void AddMonpoke(Monpoke monpoke)
        {
            monpokes.Add(monpoke);
        }

        public Monpoke GetMonpoke(string id)
        {
            return monpokes.FirstOrDefault(m => m.Id == id);
        }

        private List<Monpoke> monpokes = new List<Monpoke>();
    }
}
