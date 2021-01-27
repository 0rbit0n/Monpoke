using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod]
        public void MonpokeMustHave1HPOrGreater()
        {
            var hitPoints = 0;

            Action createMonpoke = () => new Monpoke("monpoke", hitPoints: hitPoints, attackPower: 100);

            createMonpoke.Should().Throw<ArgumentException>().WithMessage("Monpoke must have 1 HP or greater (Parameter 'hitPoints')");
        }

        [TestMethod]
        public void MonpokeMustHave1APOrGreater()
        {
            var attackPower = 0;

            Action createMonpoke = () => new Monpoke("monpoke", hitPoints: 1, attackPower: attackPower);

            createMonpoke.Should().Throw<ArgumentException>().WithMessage("Monpoke must have 1 AP or greater (Parameter 'attackPower')");
        }

        [TestMethod]
        public void MonpokeCanHealHealth()
        {
            var hitPoint = 10;
            var monpoke = new Monpoke("monpoke", hitPoints: hitPoint, attackPower: 5);
            monpoke.Damage(9);
            monpoke.Heal(5);

            var expectedMonpoke = new Monpoke("monpoke", hitPoints: 10 - 9 + 5, attackPower: 5);
            expectedMonpoke.SetField("originalHitPoints", 10);

            var actualMonpoke = monpoke;

            actualMonpoke.ShouldHaveSameStateAs(expectedMonpoke);
        }

        [TestMethod]
        public void AttackPowerIsCorrect()
        {
            var attackPower = 10;
            var monpoke = new Monpoke("monpoke", hitPoints: 10, attackPower: attackPower);

            monpoke.GetAttackPower().Should().Be(attackPower);
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
