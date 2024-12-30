namespace TextFilterTests.TextFilters;

public class MiddleVowelFilterTests
{
    internal MiddleVowelFilter MiddleVowelFilter { get; }
    public MiddleVowelFilterTests()
    {
        MiddleVowelFilter = new MiddleVowelFilter();
    }

    [Theory]
    [InlineData("thks shkll rempin")]
    [InlineData("thks shkll rempjnr")]
    [InlineData("thps shkll rempin")]
    [InlineData("")]
    public void ApplyFilter_MiddleIsConsonants_NotRemoved(string line)
    {
        var filteredWord = MiddleVowelFilter.ApplyFilter(line);
        filteredWord.ShouldBe(line);
    }
    //testing all vowels
    [Theory]
    [InlineData("this shAll shall weut wEUt be remOved thpse thhpse", "be thpse thhpse")]
    [InlineData("clEan clean what (woat)  whOAt currently the rather", "() the rather")]
    [InlineData("clian clIan heck pjjk what wIet whiEt currently the rather", "pjjk the rather")]
    [InlineData("clion clIOn what woit wOIt currently the rather", "the rather")]
    [InlineData("clUan cluun what wUot wuot currently the rather llng", "the rather llng")]
    [InlineData("conversation?'So converaation?'Sop converaation?'Syp", "conversation?'So ?' ?'Syp")]
    [InlineData("?'conversation ?converaation?'Sop", "?'conversation ??'")]
    [InlineData("some other sentence be partially removed ", "other be")]
    public void ApplyFilter_MiddleIsVowelAndConsonant_PartialRemoved(string line, string expected)
    {
        var filteredWord = MiddleVowelFilter.ApplyFilter(line);
        filteredWord.ShouldBe(expected);
    }

    [Theory]
    [InlineData("theis shall beg removed")]
    [InlineData("clean whiat currently ratoher")]
    [InlineData("soame otier sentience partially removed")]
    [InlineData("soame oteer even sentience partoally remuved")]
    public void ApplyFilter_MiddleIsVowel_Removed(string line)
    {
        var filteredWord = MiddleVowelFilter.ApplyFilter(line);
        filteredWord.ShouldBe(string.Empty);
    }

    [Fact]
    public void ApplyFilter_Null_Returns_EmptyString()
    {
        var filteredWord = MiddleVowelFilter.ApplyFilter(null);
        filteredWord.ShouldBe(string.Empty);
    }
}
