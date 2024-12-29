using System.Text;
using TextFilter.Helpers;

namespace TextFilter.TextFilters
{
    internal class LengthFilter(int minSize) : BaseTextFilter
    {

        public override string ApplyFilter(string line)
        {

            if (line == null)
            {
                return String.Empty;
            }
            var words = line.Split(' ');
            var maxIndex = words.Length;
            var sb = new StringBuilder();
            for (long i = 0; i < maxIndex; i++)
            {
                var word = words[i];
                if (word.Length >= minSize)
                {
                    sb.Append(LineHelper.LastWordAddWhitespace(i, maxIndex, word));
                }
            }
            return sb.ToString().Trim();
        }
    }
}
