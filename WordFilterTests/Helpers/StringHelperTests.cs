using TextFilter.Helpers;

namespace TextFilterTests.Helpers
{
    public class StringHelperTests
    {
        [Fact]
        public void ReplaceMultipleWhitespace_Empty_Returns_EmptyString()
        {
            "".ReplaceMultipleWhitespace().ShouldBe(string.Empty);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("   ")]
        public void ReplaceMultipleWhitespace_Whitespace_Returns_EmptyString(string line)
        {
            line.ReplaceMultipleWhitespace().ShouldBe(string.Empty);
        }

        [Theory]
        [InlineData(" c", "c")]
        [InlineData(" c ", "c")]
        [InlineData("  Calastone  Interview ", "Calastone Interview")]
        public void ReplaceMultipleWhitespace_Multiplewhitespace_Returns_SingleWhitespace(string line, string expected)
        {
            line.ReplaceMultipleWhitespace().ShouldBe(expected);
        }
    }
}
