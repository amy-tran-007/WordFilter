using TextFilter.Services;

namespace TextFilterTests.Services
{
    public class RegExTextEditServiceTests
    {
        //todo: add on whitespace checks
        private readonly RegExTextEditService _regExTextEditService;
        public RegExTextEditServiceTests()
        {

            _regExTextEditService = new RegExTextEditService();
        }

        [Theory]
        [InlineData("shall the pen not have the character", "i")]
        [InlineData("before sitting down she checked the chair", "x")]

        public void ContainsAnyCharacter_NoCharacterInSentence_Returns_False(string line, string searchFor)
        {
            var result = _regExTextEditService.ContainsAnyCharacter(line, searchFor);
            result.ShouldBeFalse();
        }

        [Theory]
        [InlineData("shall the pen not have the character", "a")]
        [InlineData("before sitting down she checked the chair", "t")]

        public void ContainsAnyCharacter_CharacterInSentence_Returns_True(string line, string searchFor)
        {
            var result = _regExTextEditService.ContainsAnyCharacter(line, searchFor);
            result.ShouldBeTrue();
        }

        [Fact]
        public void RemoveWord_ContainsWord_Returns_WordRemoved()
        {
            var line = "before sitting down she checked the chair for their equipment";
            var wordsToRemove = new List<string>() { "she", "the" };
            var expected = "before sitting down checked chair for their equipment";

            var result = _regExTextEditService.RemoveWord(line, wordsToRemove);
            result.ShouldBe(expected);
        }

        [Fact]
        public void RemoveWord_DoesNotContainWord_Returns_WordRemoved()
        {
            var line = "before sitting down she checked the chair for their equipment";
            var wordsToRemove = new List<string>() { "day", "seat" };

            var result = _regExTextEditService.RemoveWord(line, wordsToRemove);
            result.ShouldBe(line);
        }

        [Fact]
        public void RemoveWordContainingCharacter_DoesNotContain_Returns_line()
        {
            var line = "before sitting down she checked the chair for their equipment";
            var result = _regExTextEditService.RemoveWordContainingCharacter(line, 'x');
            result.ShouldBe(line);
        }

        [Fact]
        public void RemoveWordContainingCharacter_ContainChar_Returns_lineWithoutWords()
        {
            var line = "before sitting down she checked the chair for their equipment";
            var expected = "before sitting down for equipment";

            var result = _regExTextEditService.RemoveWordContainingCharacter(line, 'h');
            result.ShouldBe(expected);
        }

        [Fact]
        public void SplitSentenceIntoWords_Sentence_Returns_CollectionOfWords()
        {
            var line = "before sitting down, she checked the chair for their 'equipment'";
            var expected = new string[] { "before", "sitting", "down", "she", "checked", "the", "chair", "for", "their", "equipment", "" };
            var result = _regExTextEditService.SplitSentenceIntoWords(line);
            result.ShouldBe(expected);
        }
    }
}
