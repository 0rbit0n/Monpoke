namespace Monpoke
{
    public class Output : IOutput
    {
        public void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
