using System.Collections.Concurrent;
using System.Text;
using TextFilter.Containers;

namespace TextFilter.Commands;

internal class FilterCommand
{
    private ConcurrentDictionary<long, string> TextContainer = new ConcurrentDictionary<long, string>();
    public string GetFilteredText(ITextContainer container, CancellationToken cancellationToken)
    {
        //ToDo: configs should be stored in appsettings.json 
        var exceptions = new ConcurrentQueue<Exception>();
        var parallelOptions = new ParallelOptions()
        {
            MaxDegreeOfParallelism = Environment.ProcessorCount - 2,
            CancellationToken = cancellationToken
        };



        //extremely large files may exceed lineNumber
        Parallel.ForEach(container.TextContent, parallelOptions, (line, _, lineNumber) =>
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var filteredLine = container.TextFilter.ApplyFilter(line);
                    if (!string.IsNullOrWhiteSpace(filteredLine))
                    {
                        TextContainer[lineNumber - 1] = filteredLine;
                    }
                }
            }
            catch (Exception ex)
            {
                exceptions.Enqueue(ex);
            }
        });

        if (!exceptions.IsEmpty)
        {
            throw new AggregateException(exceptions);
        }

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

