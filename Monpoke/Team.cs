namespace Monpoke
{
    public class Team : ITeam
    {
        public Team(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
