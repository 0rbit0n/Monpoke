using FluentAssertions;
using KellermanSoftware.CompareNetObjects;

namespace Monpoke.Tests
{
    public static class TestsExtensions
    {
        public static void ShouldHaveSameStateAs(this object expectedObject, object actualObject)
        {
            var comparer = new CompareLogic() 
            {
                Config = new ComparisonConfig 
                { 
                    MaxDifferences = int.MaxValue, 
                    ComparePrivateFields = true 
                } 
            };

            var comparisonResults = comparer.Compare(expectedObject, actualObject);
            comparisonResults.AreEqual.Should().BeTrue(because: comparisonResults.DifferencesString);
        }
    }
}
