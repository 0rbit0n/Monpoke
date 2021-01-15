using System;
using System.Linq;

namespace Monpoke
{
    public class CommandFactory
    {
        public CreateCommand CreateCommand(string commandText)
        {
            var tokens = commandText.Split(' ').ToArray();

            var teamId = tokens[1];
            var monpokeId = tokens[2];
            var hp = Convert.ToInt32(tokens[3]);
            var attack = Convert.ToInt32(tokens[4]);

            return new CreateCommand(teamId, monpokeId, hp, attack);
        }
    }
}
