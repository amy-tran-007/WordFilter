namespace TextFilterTests.TextFilters
{
    public class RemoveCharacterFilterTests
    {

        [Theory]
        [InlineData(" this shall remhin", 'h')]
        [InlineData("the shell remoin", 'e')]
        public void ApplyFilter_ContainCharacter_Removed(string line, char match)
        {
            var filteredWord = new RemoveCharacterFilter(match).ApplyFilter(line);
            filteredWord.ShouldBe(string.Empty);
        }
        [Theory]
        [InlineData("this shall  remhin", 'o')]
        [InlineData("the shell remoin", 'u')]
        public void ApplyFilter_DoesNotContainCharacter_Remain(string line, char match)
        {
            var filteredWord = new RemoveCharacterFilter(match).ApplyFilter(line);
            filteredWord.ShouldBe(line);
        }

        [Theory]
        [InlineData("this shall  remhin shlla apple Apple", 'a', "this   remhin")]
        [InlineData("the shell unsure Us somethingu U remoin ", 'u', "the shell     remoin")]
        public void ApplyFilter_ContainSomeCharacter_Remain(string line, char match, string expected)
        {
            var filteredWord = new RemoveCharacterFilter(match).ApplyFilter(line);
            filteredWord.ShouldBe(expected);
        }

        [Fact]
        public void ApplyFilter_Null_Returns_EmptyString()
        {
            var filteredWord = new RemoveCharacterFilter('r').ApplyFilter(null);
            filteredWord.ShouldBe(string.Empty);
        }
    }
}
