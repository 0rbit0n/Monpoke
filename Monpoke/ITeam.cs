namespace Monpoke
{
    public interface ITeam
    {
        string Id { get; }

        void AddMonpoke(Monpoke monpoke);
        Monpoke GetMonpoke(string id);
        Monpoke GetCurrentMonpoke();
        void SetCurrentMonpoke(string monpokeId);
    }
}
