using System;

namespace Monpoke
{
    public class Monpoke
    {
        public Monpoke(string id, int hitPoints, int attackPower)
        {
            if (hitPoints < 1)
                throw new ArgumentException("Monpoke must have 1 HP or greater", nameof(hitPoints));

            if (attackPower < 1)
                throw new ArgumentException("Monpoke must have 1 AP or greater", nameof(attackPower));

            this.Id = id;
            this.hitPoints = hitPoints;
            this.attackPower = attackPower;
        }

        public string Id { get; }

        public int GetAttackPower()
        {
            return attackPower;
        }

        public void Damage(int damage)
        {
            hitPoints -= damage;
        }

        public bool IsAlive()
        {
            return hitPoints > 0;
        }

        public void Attack(Monpoke victim)
        {
            victim.Damage(attackPower);
        }

        private int hitPoints;
        private int attackPower;
    }
}
