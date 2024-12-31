using System.Collections.Concurrent;
using System.Text;
using TextFilter.Containers;

namespace TextFilter.Commands;

internal class FilterCommand
{
    private ConcurrentDictionary<long, string> TextContainer = new ConcurrentDictionary<long, string>();
    public string GetFilteredText(ITextContainer container)
    {
        //todo can add parallex options
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
        if (TextContainer.Count == 0)
        {
            return string.Empty;
        }
        var index = TextContainer.Keys.Min();
        var maxIndex = TextContainer.Keys.Max();
        StringBuilder sb = new StringBuilder();
        for (long i = index; i <= maxIndex; i++)
        {
            sb.AppendLine(TextContainer[i]);
        }

        return sb.ToString();
    }
}

