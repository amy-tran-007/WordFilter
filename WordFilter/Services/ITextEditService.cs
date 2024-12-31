namespace TextFilter.Services
{
    internal interface ITextEditService
    {
        public bool ContainsAnyCharacter(string sentence, string searchFor);
        public string RemoveWord(string sentence, IReadOnlyCollection<string> wordsToRemove);
        public string RemoveWordContainingCharacter(string sentence, char findChar);
        public IReadOnlyCollection<string> SplitSentenceIntoWords(string sentence);
    }
}