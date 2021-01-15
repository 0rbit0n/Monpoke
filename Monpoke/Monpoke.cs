namespace Monpoke
{
    public class Monpoke
    {
        public Monpoke(string id, int hitPoints, int attackPower)
        {
            this.Id = id;
            this.hitPoints = hitPoints;
            this.attackPower = attackPower;
        }

        public string Id { get; }

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
