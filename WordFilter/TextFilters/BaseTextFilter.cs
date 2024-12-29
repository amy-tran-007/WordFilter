namespace TextFilter.TextFilters
{
    internal abstract class BaseTextFilter
    {
        protected BaseTextFilter NextFilter = default!;

        public BaseTextFilter SetNextFilter(BaseTextFilter nextFilter)
        {
            NextFilter = nextFilter;
            return this.NextFilter;
        }

        public virtual string ApplyFilter(string line)
        {

            if (NextFilter != null)
            {
                return $"{NextFilter.ApplyFilter(line)}";
            }
            return line;
        }
    }
}
