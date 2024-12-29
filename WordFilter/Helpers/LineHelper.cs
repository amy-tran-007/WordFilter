namespace TextFilter.Helpers
{
    internal static class LineHelper
    {
        private static string AddOnWhitespaceIfNeeded(bool isLastWord, string word) =>
          (isLastWord, word) switch
          {
              (false, _) => word + " ",
              (true, _) => word,
          };

        private static bool IsLastWord(long i, long maxSize)
        {
            return (i == maxSize - 1);
        }

        public static string LastWordAddWhitespace(long i, long maxSize, string word)
        {
            var lastWord = IsLastWord(i, maxSize);
            return AddOnWhitespaceIfNeeded(lastWord, word);
        }
    }
}
