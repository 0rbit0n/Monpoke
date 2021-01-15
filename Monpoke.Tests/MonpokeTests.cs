using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monpoke.Tests
{
    [TestClass]
    public class MonpokeTests
    {
        [TestMethod]
        public void MonpokeHasId()
        {
            var monpoke = new Monpoke("monpoke", 1, 1);

            monpoke.Id.Should().Be("monpoke");
        }

        [DataTestMethod]
        [DataRow(5, 3, true,  DisplayName = "Monpoke damaged slightly is alive")]
        [DataRow(5, 5, false, DisplayName = "Monpoke damaged hard enough is dead")]
        [DataRow(5, 7, false, DisplayName = "Monpoke damaged very hard is very dead")]
        public void MonpokeDamagedHardIsDead(int initialHp, int damage, bool shouldBeAlive)
        {
            var monpoke = new Monpoke("monpoke", initialHp, attackPower: 1);

            monpoke.Damage(damage);

            monpoke.IsAlive().Should().Be(shouldBeAlive);
        }

        [DataTestMethod]
        [DataRow(5, 6, true,  DisplayName = "Weak monpoke doesn't kill victim")]
        [DataRow(5, 5, false, DisplayName = "Strong enough monpoke kills victim")]
        [DataRow(6, 5, false, DisplayName = "Very strong monpoke kills victim")]
        public void MonpokeCantAttackMoreThanAttackPoints(int attackerPower, int victimHitPoints, bool victimShouldBeAlive)
        {
            var attacker = new Monpoke("attacker", hitPoints: int.MaxValue, attackPower: attackerPower);
            var victim = new Monpoke("victim", hitPoints: victimHitPoints, attackPower: int.MaxValue);

            attacker.Attack(victim);

            victim.IsAlive().Should().Be(victimShouldBeAlive);
        }
    }
}
