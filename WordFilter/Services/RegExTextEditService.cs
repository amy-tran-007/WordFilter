using System.Text;
using System.Text.RegularExpressions;

namespace TextFilter.Services
{
    internal class RegExTextEditService : ITextEditService
    {
        //could rename the RemoveWord to accept a string.empty replacement character but I like the clarity of the name
        public bool ContainsAnyCharacter(string sentence, string searchFor)
        {
            var regex = $@"[{searchFor}]";
            Match match = Regex.Match(sentence, regex, RegexOptions.IgnoreCase);
            return match.Success;
        }

        public string RemoveWord(string sentence, IReadOnlyCollection<string> wordsToRemove)
        {
            if (wordsToRemove == null || wordsToRemove.Count() == 0) { return sentence; }
            if (string.IsNullOrWhiteSpace(sentence)) { return sentence; };

            var regExSb = new StringBuilder();

            Regex nonAlphaNumeric = new Regex("[^\\w*]+");

            foreach (var removeWord in wordsToRemove)
            {
                regExSb.Append($@"|\b({removeWord})\b");
            }

            var regex = regExSb.ToString();
            var filteredText = string.IsNullOrEmpty(regex) ? sentence :
                                Regex.Replace(sentence, regex.Substring(1), "");
            return ReplaceMultipleWhitespace(filteredText);
        }

        public string RemoveWordContainingCharacter(string sentence, char findChar)
        {
            //TODO could extend to make this fine any characters
            if (string.IsNullOrWhiteSpace(sentence)) { return string.Empty; };

            var regex = $@"\w*{findChar}\w*";
            return ReplaceMultipleWhitespace(Regex.Replace(sentence, regex, "", RegexOptions.IgnoreCase));
        }

        public IReadOnlyCollection<string> SplitSentenceIntoWords(string sentence)
        {
            Regex nonAlphaNumeric = new Regex("[^\\w*]+");
            return nonAlphaNumeric.Split(sentence);
        }

        private string ReplaceMultipleWhitespace(string line)
        {
            var regex = @"\s+\s{1,}";
            return Regex.Replace(line, regex, " ", RegexOptions.IgnoreCase).Trim();
        }
    }
}
