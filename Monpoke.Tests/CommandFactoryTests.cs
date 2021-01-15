using FluentAssertions;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monpoke.Tests
{
    [TestClass]
    public class CommandFactoryTests
    {
        [TestMethod]
        public void CanCreateCreateCommand()
        {
            var factory = new CommandFactory();
            var actualCommand = factory.CreateCommand("CREATE Rocket Meekachu 3 1");

            var expectedCommand = new CreateCommand(teamId: "Rocket", monpokeId: "Meekachu", hp: 3, attack: 1);

            var comparer = new CompareLogic() 
            {
                Config = new ComparisonConfig 
                { 
                    MaxDifferences = int.MaxValue, 
                    ComparePrivateFields = true 
                } 
            };

            var comparisonResults = comparer.Compare(expectedCommand, actualCommand);
            comparisonResults.AreEqual.Should().BeTrue(because: comparisonResults.DifferencesString);
        } 
    }
}
