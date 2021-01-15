namespace Monpoke
{
    public interface IGame
    {
        void AddTeam(ITeam team);
        ITeam GetTeam(string teamId);

        void Run();
    }
}
