using System.Collections.Concurrent;
using System.Text;
using TextFilter.Containers;

namespace TextFilter.Commands
{
    internal class FilterCommand
    {
        private ConcurrentDictionary<long, string> OrderedTextContainer = new ConcurrentDictionary<long, string>();
        public string GetFilteredText(ITextContainer container)
        {

            StringBuilder sb = new StringBuilder();
            Parallel.ForEach(container.TextContent, (line, _, lineNumber) =>
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var filteredLine = container.TextFilter.ApplyFilter(line);
                    if (!string.IsNullOrWhiteSpace(filteredLine))
                    {
                        OrderedTextContainer[lineNumber] = filteredLine;
                        sb.Append(filteredLine);
                    }
                }

            });

            return sb.ToString();
        }
    }
}

