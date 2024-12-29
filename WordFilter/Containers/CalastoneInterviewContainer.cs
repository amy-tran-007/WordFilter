using TextFilter.TextFilters;

namespace TextFilter.Containers
{
    internal class CalastoneInterviewContainer(string fileLocation) : FileContainer(fileLocation)
    {

        protected const int MINIMUM_WORD_LENGTH = 3;
        private const char FILTER_BY_CHAR = 't';
        public override BaseTextFilter TextFilter
        {
            get
            {
                var filter = new MiddleVowelFilter();
                filter.SetNextFilter(new LengthFilter(MINIMUM_WORD_LENGTH))
                .SetNextFilter(new RemoveCharacterFilter(FILTER_BY_CHAR));
                return filter;
            }
        }

    }
}
