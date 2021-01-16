﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monpoke.Tests
{
    [TestClass]
    public class GameOverTests
    {
        [TestInitialize]
        public void ArrangeAct()
        {
            var team1 = new Team("team1");
            var monpoke1 = new Monpoke("monpoke1", 1, 1);
            team1.AddMonpoke(monpoke1);

            var team2 = new Team("team2");
            var monpoke2 = new Monpoke("monpoke2", 1, 1);
            team2.AddMonpoke(monpoke2);

            game.AddTeam(team1);
            game.AddTeam(team2);

            monpoke1.Attack(monpoke2);
        }

        [TestMethod]
        public void GameIsOverWhenTeamHasNoAliveMonpokes()
        {
            game.IsOver().Should().BeTrue();
        }

        IGame game = new Game();
    }
}
