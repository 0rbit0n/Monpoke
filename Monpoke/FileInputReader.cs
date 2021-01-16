using System.IO;
using System.Linq;

namespace Monpoke
{
    public class FileInputReader : IInputReader
    {
        public FileInputReader(string path)
        {
            this.path = path;
        }

        public string[] ReadInput()
        {
            return File.ReadAllLines(path).Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();
        }

        private string path;
    }
}
