using System.Text;
using System.Text.Json.Serialization;
using WordCountLib.TextAnalysisString;

namespace WordCountLib.TextAnalysis.Object
{
    public class TextAnalysisResult : IFormattedString {
        [JsonIgnore]
        private string sentence;

        [JsonIgnore]
        private string[] splitSentence;
    
        public int WordAmount { get; set;}
        public double AverageWordLength { get; set; }
        public Dictionary<int, int> NumberOfWordsOfLength { get; set; }
        public Dictionary<int, int> HighestOccurringWordLength { get; set; }

        public TextAnalysisResult()
        {
        }

        public TextAnalysisResult(string sentence)
        {
            this.sentence = sentence;
        }

        public TextAnalysisResult(string sentence, string[] splitSentence,
                                  int wordAmount, double averageWordLength,
                                  Dictionary<int, int> numberOfWordsOfLength,
                                  Dictionary<int, int> highestOccurringWordLength)
        {
            this.sentence = sentence;
            this.splitSentence = splitSentence;
            this.WordAmount = wordAmount;
            this.AverageWordLength = averageWordLength;
            this.NumberOfWordsOfLength = numberOfWordsOfLength;
            this.HighestOccurringWordLength = highestOccurringWordLength;
        }

        public string getSentence()
        {
            return sentence;
        }

        public void setSentence(string sentence)
        {
            this.sentence = sentence;
        }

        public string[] getSplitSentence()
        {
            return splitSentence;
        }

        public void setSplitSentence(string[] splitSentence)
        {
            this.splitSentence = splitSentence;
        }

        public string ToFormattedString()
        {
            StringBuilder returnString = new StringBuilder();

            returnString.Append(string.Format("Word count = {0} \n", this.WordAmount));
            returnString.Append(string.Format("Average Word Length = {0} \n", this.AverageWordLength));
            foreach(var pair in NumberOfWordsOfLength)
            {
                returnString.Append(string.Format("Number of words of length {0} is {1} \n", pair.Key, pair.Value));
            }
            returnString.Append(
                    string.Format("The most frequently occurring word length is {0}, for word lengths of {1} \n",
                    this.NumberOfWordsOfLength.First().Value,
                    String.Join(",", this.HighestOccurringWordLength.Keys.ToArray())));

            return returnString.ToString();
        }
    }
}
