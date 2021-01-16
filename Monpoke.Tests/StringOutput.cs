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

        public void Clear()
        {
            builder.Clear();
        }

        StringBuilder builder = new StringBuilder();
    }
}
