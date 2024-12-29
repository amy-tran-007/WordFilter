using System.Text;
using System.Text.RegularExpressions;

namespace TextFilter.TextFilters
{
    internal class MiddleVowelFilter : BaseTextFilter
    {
        //could use regex but not a regex expert and many people aren't so doing this for clarity
        //words less than 2 character length is excluded from filter as middle doesn't exist
        protected override string MyFilter => "Middle";
        public override string ApplyFilter(string line)
        {
            if (line == null)
            {
                return String.Empty;
            }

            var words = line.Split(' ');
            var sb = new StringBuilder();
            var maxIndex = words.Length;

            for (long i = 0; i < maxIndex; i++)
            {
                var word = words[i];
                if (word.Length <= 2)
                {
                    sb.Append(AddOnWhitespaceIfNeeded(IsLastWord(i, maxIndex), word));
                    continue;
                }

                var middleCharacters = word.Length % 2 == 0 ? word.Substring(word.Length / 2 - 1, 2) : word.Substring(word.Length / 2, 1);
                if (!ContainsAllVowels(middleCharacters))
                {
                    sb.Append(AddOnWhitespaceIfNeeded(IsLastWord(i, maxIndex), word));
                }
            }

            var filteredText = sb.ToString();
            return base.ApplyFilter(filteredText);
        }
        private string AddOnWhitespaceIfNeeded(bool isLastWord, string word) =>
           (isLastWord, word) switch
           {
               (false, _) => word + " ",
               (true, _) => word,
           };

        private bool IsLastWord(long i, long maxSize)
        {
            return (i == maxSize - 1);
        }
        private bool ContainsAllVowels(string word)
        {
            var regex = @"^[aeiou]+$";
            Match match = Regex.Match(word, regex, RegexOptions.IgnoreCase);
            return match.Success;
        }
    }
}
