using System.Text.RegularExpressions;

namespace TextFilter.TextFilters
{
    internal class RemoveCharacterFilter(char removeChar) : BaseTextFilter
    {
        public override string ApplyFilter(string line)
        {
            //TODO removestring will need to be escaped for special characters
            //wasn't sure about the whitespace here but I've left in.
            //would see clarification of the whitespace in a work setting
            if (line == null)
            {
                return String.Empty;
            }
            var sdf = removeChar;
            var regex = $@"\S*{removeChar}\S*";
            return Regex.Replace(line, regex, "", RegexOptions.IgnoreCase).Trim();

        }
    }
}
