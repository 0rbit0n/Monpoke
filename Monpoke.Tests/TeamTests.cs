using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monpoke.Tests
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void NewTeamHasId()
        {
            var team = new Team("my-team");

            team.Id.Should().Be("my-team");
        }

        [TestMethod]
        public void CanAddMonpokeToTeam()
        {
            var team = new Team("team");
            var monpoke = new Monpoke("monpoke", 1, 1);

            team.AddMonpoke(monpoke);

            team.GetMonpoke("monpoke").Should().Be(monpoke);
        }
    }
}
