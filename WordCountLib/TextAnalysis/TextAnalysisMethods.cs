namespace WordCountLib.TextAnalysis
{
    public class TextAnalysisMethods
    {
        public int GetWordCount(string[] processedSentence)
        {
            return processedSentence.Length;
        }

        public double GetAverageWordLength(string[] processedSentence)
        {
            return processedSentence.Sum((word) => word.Length) / processedSentence.Length;
        }

        public Dictionary<int, int> GetNumberOfWordsOfLengthMap(string[] processedSentence)
        {
            return processedSentence
                .GroupBy((word) => word.Length)
                .ToDictionary(word => word.Key, word => word.Sum((word) => 1));
        }

        public Dictionary<int, int> GetMostOccurringWordLength(
                Dictionary<int, int> processedSentenceMap)
        {
            return processedSentenceMap
                .Where((keyPair) => keyPair.Value == processedSentenceMap.Max((keyPair) => keyPair.Value))
                .ToDictionary(i => i.Key, i => i.Value);
        }
    }
}
