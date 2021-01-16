using System.Text;

namespace Monpoke.Tests
{
    public class StringOutput : IOutput
    {
        public void WriteLine(string message)
        {
            builder.AppendLine(message);
        }

        public string GetText()
        {
            return builder.ToString();
        }

        StringBuilder builder = new StringBuilder();
    }
}
