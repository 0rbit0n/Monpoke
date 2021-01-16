using System.Linq;

namespace Monpoke
{
    public class ConsoleInputReader : IInputReader
    {

        public string[] ReadInput()
        {
            return System.Console.In
                         .ReadToEnd()
                         .Split(System.Environment.NewLine)
                         .Where(l => !string.IsNullOrWhiteSpace(l))
                         .ToArray();
        }
    }
}
