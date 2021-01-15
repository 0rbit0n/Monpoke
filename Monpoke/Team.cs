using System.Linq;
using System.Collections.Generic;
using System;

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

        public Monpoke GetCurrentMonpoke()
        {
            if (currentMonpoke == null)
                throw new Exception($"Current Monpoke is not set on the team '{Id}'.");

            return currentMonpoke;
        }

        public void SetCurrentMonpoke(string monpokeId)
        {
            var monpoke = monpokes.FirstOrDefault(m => m.Id == monpokeId);

            if (monpoke == null)
                throw new Exception($"Can't set monpoke '{monpokeId}' as current because it isn't added to team '{Id}'.");

            currentMonpoke = monpoke;
        }

        public bool HasAliveMonpoke()
        {
            return monpokes.Any(m => m.IsAlive());
        }

        private List<Monpoke> monpokes = new List<Monpoke>();
        private Monpoke currentMonpoke;
    }
}
