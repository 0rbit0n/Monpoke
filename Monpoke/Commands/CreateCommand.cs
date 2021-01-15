﻿namespace Monpoke.Commands
{
    public class CreateCommand : ICommand
    {
        public CreateCommand(string teamId, string monpokeId, int hp, int attack)
        {
            this.teamId = teamId;
            this.monpokeId = monpokeId;
            this.hp = hp;
            this.attack = attack;
        }

        public void Execute(IGame game)
        {
            throw new System.NotImplementedException();
        }

        private string teamId;
        private string monpokeId;
        private int hp;
        private int attack;
    }
}
