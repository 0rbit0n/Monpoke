using Monpoke.Commands;

namespace Monpoke
{
    public interface IGame
    {
        void AddTeam(ITeam team);
        ITeam GetTeam(string teamId);
        ITeam GetCurrentTeam();
        ITeam GetWaitingTeam();
        void MakeTurn(ICommand emptyCommand);
    }
}
