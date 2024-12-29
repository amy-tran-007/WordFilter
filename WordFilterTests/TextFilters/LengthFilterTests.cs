
namespace TextFilterTests.TextFilters
{
    public class LengthFilterTests
    {
        [Theory]
        [InlineData(" this shall be removed ", 10)]
        [InlineData("clean what currently the rather", 20)]
        [InlineData("some other sentence be partially removed ", 30)]
        [InlineData(" ", 30)]

        public void ApplyFilter_WordsLessThanLength_Removed(string line, int minimumLength)
        {
            var filteredWord = new LengthFilter(minimumLength).ApplyFilter(line);
            filteredWord.ShouldBe(string.Empty);
        }

        [Theory]
        [InlineData("this shall removed the", 3)]
        [InlineData("clean what currently the rather", 2)]
        [InlineData("other sentence", 5)]
        public void ApplyFilter_WordsGreaterThanLength_Remains(string line, int minimumLength)
        {
            var filteredWord = new LengthFilter(minimumLength).ApplyFilter(line);
            filteredWord.ShouldBe(line);
        }

        [Theory]
        [InlineData("something shall be removed", 3, "something shall removed")]
        [InlineData("clean what currently the rather", 5, "clean currently rather")]
        [InlineData("other sentence the mix", 5, "other sentence")]
        [InlineData("  other sentence the mix ", 5, "other sentence")]
        public void ApplyFilter_MixedWordsLength_PartiallyReplaced(string line, int minimumLength, string expected)
        {
            var filteredWord = new LengthFilter(minimumLength).ApplyFilter(line);
            filteredWord.ShouldBe(expected);
        }

        [Fact]
        public void ApplyFilter_Null_Returns_EmptyString()
        {
            var filteredWord = new LengthFilter(3).ApplyFilter(null);
            filteredWord.ShouldBe(string.Empty);
        }
    }
}
