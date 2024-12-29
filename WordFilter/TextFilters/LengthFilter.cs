using System.Text;

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
            var words = line.Split(" ");
            var sb = new StringBuilder();
            foreach (var word in words)
            {

                if (word.Length >= minSize)
                {
                    sb.Append(word + " ");
                }
            }
            return base.ApplyFilter(sb.ToString().Trim());
        }
    }
}
