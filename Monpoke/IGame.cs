using Monpoke.Commands;

namespace Monpoke
{
    public interface IGame
    {
        void AddTeam(ITeam team);
        ITeam GetTeam(string teamId);
        ITeam GetCurrentTeam();
        void MakeTurn(ICommand emptyCommand);
    }
}
