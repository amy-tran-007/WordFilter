using System.Collections.Concurrent;
using System.Text;
using TextFilter.Containers;

namespace TextFilter.Commands
{
    internal class FilterCommand
    {
        private ConcurrentDictionary<long, string> TextContainer = new ConcurrentDictionary<long, string>();
        public string GetFilteredText(ITextContainer container)
        {

            Parallel.ForEach(container.TextContent, (line, _, lineNumber) =>
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var filteredLine = container.TextFilter.ApplyFilter(line);
                    if (!string.IsNullOrWhiteSpace(filteredLine))
                    {
                        TextContainer[lineNumber - 1] = filteredLine;
                    }
                }
            });


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < TextContainer.Count; i++)
            {
                sb.AppendLine(TextContainer[i]);
            }

            return sb.ToString();
        }
    }
}

