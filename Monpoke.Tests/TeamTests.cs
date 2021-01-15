using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod]
        public void CantGetCurrentMonpokeWhenItsNotSet()
        {
            var team = new Team("team");

            Action getCurrentMonpoke = () => team.GetCurrentMonpoke();

            getCurrentMonpoke.Should().Throw<Exception>().WithMessage("Current Monpoke is not set on the team 'team'.");
        }

        [TestMethod]
        public void CantSetCurrentMonpoke()
        {
            var team = new Team("team");

            var monpoke = new Monpoke("monpoke", 1, 1);

            team.AddMonpoke(monpoke);

            team.SetCurrentMonpoke("monpoke");

            team.GetCurrentMonpoke().Should().Be(monpoke);
        }

        [TestMethod]
        public void CantSetCurrentMonpokeToUnexistingOne()
        {
            var team = new Team("team");

            var monpoke = new Monpoke("monpoke", 1, 1);

            Action setMonpoke = () => team.SetCurrentMonpoke("unexisting-monpoke");

            setMonpoke.Should().Throw<Exception>().WithMessage("Can't set monpoke 'unexisting-monpoke' as current because it isn't added to team 'team'.");
        }
    }
}
