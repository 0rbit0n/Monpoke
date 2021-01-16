namespace Monpoke.Commands
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandText);
    }
}
