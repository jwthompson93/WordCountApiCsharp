using WordCountLib.Format;
using WordCountLib.TextAnalysis.Object;
using WordCountLib.TextAnalysis;

namespace WordCountLib.Process
{
    public class TextAnalysisProcess : IProcess<string> {

    private TextAnalysisMethods textAnalysis;

    public TextAnalysisProcess()
    {
        this.textAnalysis = new TextAnalysisMethods();
    }

    public string Process(string input, string format)
    {
        string clensedInput = input.Trim().Replace(TextAnalysisString.Regex.REMOVE_COMMAS_AND_DOTS, "").Replace(" +", " ");
        string[] splitCleansedInput = clensedInput.Split(" ");

        var textAnalysisResult = performTextAnalysis(input, splitCleansedInput);

        string returnString = FormatFactory.Format(textAnalysisResult, format);
        return returnString;
    }

    private TextAnalysisResult performTextAnalysis(string input, string[] splitInput)
    {
        var textAnalysisResult = new TextAnalysisResult(input);

        textAnalysisResult.WordAmount = textAnalysis.GetWordCount(splitInput);
        textAnalysisResult.AverageWordLength = textAnalysis.GetAverageWordLength(splitInput);
        textAnalysisResult.NumberOfWordsOfLength = textAnalysis.GetNumberOfWordsOfLengthMap(splitInput);
        textAnalysisResult.HighestOccurringWordLength = 
                textAnalysis.GetMostOccurringWordLength(textAnalysisResult.NumberOfWordsOfLength);

        return textAnalysisResult;
    }

}

}
