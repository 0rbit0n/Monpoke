using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monpoke.Commands;

namespace Monpoke.Tests
{
    [TestClass]
    public class HealCommandHealsMonpokeTests
    {
        [DataTestMethod]
        [DataRow(5, 4, 2, 3, DisplayName = "Monpoke can heal a little bit")]
        [DataRow(5, 4, 10, 5, DisplayName = "Monpoke can't heal more that initial hit power level")]
        public void MonpokeCanBeHealed(int initialHitPoints, int attackPoint, int healAmount, int expectedHitPoint)
        {
            var game = new Game(new StringOutput());

            game.RunCommand(new CreateCommand(new StringOutput(), "Team1", "Monpoke1", hp: initialHitPoints, attack: 5));
            game.RunCommand(new CreateCommand(new StringOutput(), "Team2", "Monpoke2", hp: int.MaxValue, attack: attackPoint));
            game.RunCommand(new IChooseYouCommand(new StringOutput(), "Monpoke1"));
            game.RunCommand(new IChooseYouCommand(new StringOutput(), "Monpoke2"));
            game.RunCommand(new IChooseYouCommand(new StringOutput(), "Monpoke1"));
            game.RunCommand(new AttackCommand(new StringOutput()));
            game.RunCommand(new HealCommand(new StringOutput(), healAmount));

            var expectedmonpoke = new Monpoke("Monpoke1", hitPoints: expectedHitPoint, attackPower: 5);
            expectedmonpoke.SetField("originalHitPoints", initialHitPoints);
            var actualMonpoke = game.GetTeam("Team1").GetCurrentMonpoke();

            actualMonpoke.ShouldHaveSameStateAs(expectedmonpoke);
        }
    }
}