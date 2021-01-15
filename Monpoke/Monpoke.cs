using System;

namespace Monpoke
{
    public class Monpoke
    {
        public Monpoke(string id, int hp, int attack)
        {
            this.Id = id;
            this.hp = hp;
            this.attack = attack;
        }

        public string Id { get; }

        public void Damage(int damage)
        {
            hp -= damage;
        }

        public bool IsAlive()
        {
            return hp > 0;
        }

        private int hp;
        private int attack;
    }
}
