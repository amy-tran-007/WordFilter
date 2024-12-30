namespace TextFilterTests.Helpers;

public class LineHelperTests
{
    [Fact]
    public void LastWordAddWhitespace_NotLastWord_Returns_WordWithWhitespace()
    {
        //var result = LineHelper.LastWordAddWhitespace(3, 5, "hello");
        //result.ShouldBe("hello ");
    }

    [Fact]
    public void LastWordAddWhitespace_LastWord_Returns_Word()
    {
        //var result = LineHelper.LastWordAddWhitespace(4, 5, "hello");
        //result.ShouldBe("hello");
    }
}
