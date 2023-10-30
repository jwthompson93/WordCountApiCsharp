using WordCountLib.File;
using WordCountLib.Process;

namespace WordCountApi.Facade
{
    public class TextAnalysisControllerFacade
    {
        private TextAnalysisProcess textAnalysisProcess;

        public TextAnalysisControllerFacade()
        {
            this.textAnalysisProcess = new TextAnalysisProcess();
        }

        public String ProcessFileToOutputtedFormat(Stream inputStream, String outputType)
        {
            TextFileReader fileReader = new TextFileReader();
            String text = fileReader.getTextFromFile(inputStream);

            String responseString = textAnalysisProcess.Process(text, outputType);
            return responseString;
        }
    }
}
