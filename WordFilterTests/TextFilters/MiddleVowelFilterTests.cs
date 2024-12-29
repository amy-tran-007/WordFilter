using Shouldly;
using TextFilter.TextFilters;

namespace TextFilterTests.TextFilters
{
    public class MiddleVowelFilterTests
    {
        internal MiddleVowelFilter MiddleVowelFilter { get; }
        public MiddleVowelFilterTests()
        {
            MiddleVowelFilter = new MiddleVowelFilter();
        }

        [Theory]
        [InlineData(" this shkll rempin ")]
        [InlineData(" this shkll rempin  ")]
        [InlineData("  this shkll rempin  ")]
        [InlineData("    ")]
        [InlineData("")]
        public void ApplyFilter_MiddleIsConsonants_NotRemoved(string line)
        {
            var filteredWord = MiddleVowelFilter.ApplyFilter(line);
            filteredWord.ShouldBe(line);
        }

        [Theory]
        [InlineData(" this shall be removed ", " this be ")]
        [InlineData("clean what currently the rather", "what the rather")]
        [InlineData("some other sentence be partially removed ", "some other sentence be ")]
        public void ApplyFilter_MiddleIsVowelAndConsonant_PartialRemoved(string line, string expected)
        {
            var filteredWord = MiddleVowelFilter.ApplyFilter(line);
            filteredWord.ShouldBe(expected);
        }

        [Fact]
        public void ApplyFilter_Null_Returns_EmptyString()
        {
            var filteredWord = MiddleVowelFilter.ApplyFilter(null);
            filteredWord.ShouldBe(string.Empty);
        }
    }
}
