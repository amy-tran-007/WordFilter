namespace TextFilter.TextFilters
{
    internal abstract class BaseTextFilter
    {
        protected BaseTextFilter NextFilter = default!;
        protected abstract string MyFilter { get; }


        public BaseTextFilter SetNextFilter(BaseTextFilter nextFilter)
        {
            NextFilter = nextFilter;
            return this.NextFilter;
        }

        public virtual string ApplyFilter(string? line)
        {

            if (NextFilter != null)
            {
                return $"{MyFilter} {NextFilter.ApplyFilter(line)}";
            }
            return MyFilter;
        }
    }
}
