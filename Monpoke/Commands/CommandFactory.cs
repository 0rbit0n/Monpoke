﻿using System;
using System.Linq;

namespace Monpoke.Commands
{
    public class CommandFactory
    {
        public ICommand CreateCommand(string commandText)
        {
            var tokens = commandText.Split(' ').ToArray();

            var command = tokens[0];
            var parameters = tokens.Skip(1).ToArray();

            switch(command)
            {
                case "CREATE":
                    return BuildCreateCommand(parameters);
                case "ATTACK":
                    return BuildAttachCommand();
                default:
                    return null;
            }
        }

        private ICommand BuildCreateCommand(string[] parameters)
        {
            var teamId = parameters[0];
            var monpokeId = parameters[1];
            var hp = Convert.ToInt32(parameters[2]);
            var attack = Convert.ToInt32(parameters[3]);

            return new CreateCommand(teamId, monpokeId, hp, attack);
        }

        private ICommand BuildAttachCommand()
        {
            return new AttackCommand();
        }

    }
}
